using Microsoft.AspNetCore.Authorization;

namespace Utvikler_portal.Shared.Policies;

public static class HandlerRegistration
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationHandler, UserIdAuthorizationHandler>();
        services.AddScoped<IAuthorizationHandler, JobIdAuthorizationHandler>();
        services.AddAuthorization(options => {
            options.AddPolicy("userIdPolicy", policy => policy.Requirements.Add(new UserIdAuthorizationRequirement()));
            options.AddPolicy("jobIdPolicy", policy => policy.Requirements.Add(new JobIdAuthorizationRequirement()));
            });

        return services;
    }
}
