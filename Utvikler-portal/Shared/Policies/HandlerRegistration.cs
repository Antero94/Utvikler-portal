using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;

namespace Utvikler_portal.Shared.Policies;

public static class HandlerRegistration
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, IdAuthorizationHandler>();
        services.AddAuthorization(options =>
            options.AddPolicy("userIdPolicy", policy => policy.Requirements.Add(new IdAuthorizationRequirement())));

        return services;
    }
}
