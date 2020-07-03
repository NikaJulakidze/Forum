using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Service.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class SearchController : BaseController
    {
        private readonly IAccountService _accountService;

        public SearchController(IAccountService accountService)
        {
            _accountService = accountService;
        }

    }
}
