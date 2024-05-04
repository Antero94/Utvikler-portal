using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Utvikler_portal.Shared.Policies;

public class UserIdAuthorizationHandler : AuthorizationHandler<UserIdAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserIdAuthorizationRequirement requirement)
    {
        if (context.Resource is HttpContext httpContext)
        {
            var routeData = httpContext.GetRouteData();
            if (routeData.Values.TryGetValue("userId", out var value))
            {
                var parameterId = value?.ToString();
                var claimsId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

                if (Guid.TryParse(parameterId, out var id) == Guid.TryParse(claimsId, out var id2))
                {
                    context.Succeed(requirement);
                }
                else context.Fail();
            }
            else context.Fail();
        }
        else context.Fail();
        return Task.CompletedTask;
    }
}
