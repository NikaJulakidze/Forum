using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.WebUI.Attributes
{
    public class ClaimAuthorizeAttribute:AuthorizeAttribute
    {
        public string Permissions { get; set; }
    }
}
