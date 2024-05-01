using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Utvikler_portal.Shared.Policies;

public class IdAuthorizationHandler : AuthorizationHandler<IdAuthorizationRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdAuthorizationRequirement requirement)
    {
        if (context.Resource is HttpContext httpContext)
        {
            var routeData = httpContext.GetRouteData();
            if (routeData.Values.TryGetValue("userId", out var value))
            {
                var parameterId = value?.ToString();
                var ClaimsId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;

                if (Guid.TryParse(parameterId, out var id) == Guid.TryParse(ClaimsId, out var id2))
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
