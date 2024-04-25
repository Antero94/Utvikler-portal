using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Utvikler_portal.Auth.Repository;
using Utvikler_portal.Auth.Services;

namespace Utvikler_portal.Auth.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddAuth(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddTransient<ITokenService, TokenService>();
        services.AddTransient<IEncryptionService, EncryptionService>();
        services.AddTransient<IMemberService, MemberService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{

            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidAudience = configuration.GetSection("AccessTokenOptions")["Audience"],
                ValidIssuer = configuration.GetSection("AccessTokenOptions")["Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration.GetSection("AccessTokenSecretKey")["Audience"]!)
                ),
                ClockSkew=TimeSpan.Zero                    
            };
        });
        return services;
    }
}