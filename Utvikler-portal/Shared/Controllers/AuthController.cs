using Microsoft.AspNetCore.Mvc;
using Utvikler_portal.Auth.DTO;
using Utvikler_portal.Auth.Exceptions;
using Utvikler_portal.Auth.Services;

namespace Utvikler_portal.Shared.Controllers;

public class AuthController : Controller
{
    private readonly IMemberService _memberService;

    public AuthController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterMemberRequest request)
    {
        try
        {
            var response = await _memberService.RegisterMember(request);
            return Ok(response);
        }
        catch (InvalidEmailException e)
        {
            return BadRequest(e.Message);
        }
        catch (InvalidPasswordException e)
        {
            return BadRequest(e.Message);
        }
        catch (InvalidUserTypeException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception )
        {
            return BadRequest(
                "service exception occurred, please try agin later or if the error persist contact support");
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        try
        {
            var response = await _memberService.Login(request);
            return Ok(response);
        }
        catch (InvalidPasswordException e )
        {
            return BadRequest(e.Message);
        }
        catch (MemberNotFoundException e )
        {
            return NotFound(e.Message);
        }
        catch (Exception )
        {
            return BadRequest("service exception occurred, please try agin later or if the error persist contact support");
        }
    }
}