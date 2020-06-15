using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Forum.Service.CustomPolicy
{
    public class AdminPolicy : IAuthorizationRequirement
    {

    }

    public class AdminPolicyHandler : AuthorizationHandler<AdminPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminPolicy requirement)
        {
            if (context.User.HasClaim(c=>c.Type== StaticClaims.IsAdmin&& c.Value=="Yes"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
