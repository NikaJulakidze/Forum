using System.Linq;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet("index")]
        public  IActionResult Index()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}