using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Utvikler_portal.Auth.ValueObjects;

namespace Utvikler_portal.Auth.Services;

public class TokenService:ITokenService
{

    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private string GenerateJwt(string secretKey, string issuer, string audience, double expires, List<Claim> claims=null!)
    {
        var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var signinCredentials = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            
        JwtSecurityToken token = new JwtSecurityToken
        (
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expires),
            signingCredentials: signinCredentials
        );
        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
    public string GenerateAccessToken(int Id, string name, string email,UserType type)
    {
            
        List<Claim> claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, name),
            new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role,type.Value),
        };
            
        var accessToken = GenerateJwt(
            _configuration.GetSection("AccessTokenOptions")["AccessTokenSecretKey"]!,
            _configuration.GetSection("AccessTokenOptions")["Issuer"]!,
            _configuration.GetSection("AccessTokenOptions")["Audience"]!,
            Convert.ToInt32(_configuration.GetSection("AccessTokenOptions")["AccessTokenExpirationMinutes"]!),
            claims
        );
        return accessToken;
    }
}