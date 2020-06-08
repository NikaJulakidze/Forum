using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.AuthorizationPolicyHandlers
{
    public class AdminRequirement:IAuthorizationRequirement
    {
        
    }
    public class AdminAuthorizationHandler:AuthorizationHandler<AdminRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
        {
            
            throw new NotImplementedException();
        }

    }
}
