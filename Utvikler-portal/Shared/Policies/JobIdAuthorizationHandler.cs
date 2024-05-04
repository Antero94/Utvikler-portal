using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Utvikler_portal.Shared.Data;

namespace Utvikler_portal.Shared.Policies;

public class JobIdAuthorizationHandler : AuthorizationHandler<JobIdAuthorizationRequirement>
{
    private readonly UtviklerPortalDbContext _dbContext;
    public JobIdAuthorizationHandler(UtviklerPortalDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, JobIdAuthorizationRequirement requirement)
    {
        if (context.Resource is HttpContext httpContext)
        {
            var routeData = httpContext.GetRouteData();
            if (routeData.Values.TryGetValue("jobId", out var value))
            {
                var parameterId = value?.ToString();
                var claimsId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
                var userId = await _dbContext.JobPosts.FirstOrDefaultAsync(x => x.Id == Guid.Parse(parameterId!));
                var companyId = userId?.CompanyAccountId;

                if (Guid.Parse(claimsId) == companyId)
                {
                    context.Succeed(requirement);
                }
                else context.Fail();
            }
            else context.Fail();
        }
        else context.Fail();
        await Task.CompletedTask;
    }
}
