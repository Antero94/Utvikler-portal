using System.Text.RegularExpressions;
using Utvikler_portal.Auth.DTO;
using Utvikler_portal.Auth.Exceptions;
using Utvikler_portal.Auth.Models;
using Utvikler_portal.Auth.Repository;
using Utvikler_portal.Auth.ValueObjects;
using Utvikler_portal.Models.Entities;

namespace Utvikler_portal.Auth.Services;

public class MemberService:IMemberService
{
    private readonly ITokenService _tokenService;
    private readonly IEncryptionService _encryptionService;
    private readonly IAuthRepository _authRepository;

    public MemberService(
        IAuthRepository authRepository,
        IEncryptionService encryptionService,
        ITokenService tokenService)
    {
        _authRepository = authRepository;
        _encryptionService = encryptionService;
        _tokenService = tokenService;
    }

    private static bool IsValidEmail(string email)
    {
        string emailTrimed = email.Trim();

        if (!string.IsNullOrEmpty(emailTrimed))
        {
            bool hasWhitespace = emailTrimed.Contains(" ");

            int indexOfAtSign = emailTrimed.LastIndexOf('@');

            if (indexOfAtSign > 0 && !hasWhitespace)
            {
                string afterAtSign = emailTrimed.Substring(indexOfAtSign + 1);

                int indexOfDotAfterAtSign = afterAtSign.LastIndexOf('.');

                if (indexOfDotAfterAtSign > 0 && afterAtSign.Substring(indexOfDotAfterAtSign).Length > 1)
                    return true;
            }
        }

        throw new InvalidEmailException("email is invalid, please use a valid email format");
    }

    private static bool IsPasswordValid(string password)
    {
        if(!Regex.IsMatch(password, "[a-z]") && Regex.IsMatch(password, "[A-Z]"))
        {
            throw new InvalidPasswordException(
                "Password should contain a combination of upper and lower characters and at least one number");
        }
        if(!Regex.IsMatch(password, "[`,~,!,@,#,$,%,^,&,*,(,),_,-,+,=,{,[,},},|,\\,:,;,\",',<,,,>,.,?,/]"))
        {
            throw new InvalidPasswordException("Password should contain at least one special character");
        };
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new InvalidPasswordException("Password cannot be empty");
        }

        return true;
    }
        
        
    
    public async Task<RegisterMemberResponse> RegisterMember(RegisterMemberRequest request)
    {
        try
        {
            IsValidEmail(request.Email);
            IsPasswordValid(request.Password);
            HashedPassword hashedPassword = _encryptionService.EncryptPassword(request.Password);
            Member member = Member.Create(
                request.Name,
                request.UserName,
                Email.Create(request.Email),
                hashedPassword.Hash,
                hashedPassword.Salt,
                UserType.Create(request.UserType)
            );
            Member addedMember = await _authRepository.AddMember(member);
            RegisterMemberResponse response = new(addedMember.MemberId,
                addedMember.UserName,
                addedMember.Email.value,
                addedMember.UserType.Value,
                "User sucessfully registered");
            return response;
        }
        catch (InvalidUserTypeException)
        {
            throw;
        }
        catch (InvalidEmailException)
        {
            throw;
        }
        catch (InvalidPasswordException)
        {
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private void CheckMemberExists(Member? maybeMember, string email)
    {
        if (maybeMember is null)
        {
            throw new MemberNotFoundException(email);
        }
    }
    public async Task<LoginUserResponse> Login(LoginUserRequest request)
    {
        try
        {
            IsValidEmail(request.Email);
            IsPasswordValid(request.Password);
            Member? member = await _authRepository.GetMemberByEmail(Email.Create(request.Email));
            CheckMemberExists(member, request.Email);
            if (_encryptionService.VerifyPassword(request.Password, member?.Hash))
            {
                throw new InvalidPasswordException("invalid password");
            }

            string accessToken = _tokenService.GenerateAccessToken(member.MemberId,
                member.UserName,
                member.Email.value,
                member.UserType);
            LoginUserResponse response = new(accessToken, member.UserType.Value, "Login Success");
            return response;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}