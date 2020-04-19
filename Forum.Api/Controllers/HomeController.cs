using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class HomeController : ControllerBase
    {

    }
}