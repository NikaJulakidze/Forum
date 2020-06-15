using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.CustomPolicy
{
    public class UserPolicy: IAuthorizationRequirement
    {

    }

    public class UserPolicyHandler : AuthorizationHandler<UserPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserPolicy requirement)
        {
            if (context.User.IsInRole(StaticRoles.User))
                context.Succeed(requirement);
            return Task.CompletedTask;
            
        }
    }
}
