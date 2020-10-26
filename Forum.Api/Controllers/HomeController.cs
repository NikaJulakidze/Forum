using System.Linq;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [AllowAnonymous]
    public class HomeController : ControllerBase
    {
        [HttpGet("index")]
        public  IActionResult Index()
        {
            return Ok();
        }
    }
}