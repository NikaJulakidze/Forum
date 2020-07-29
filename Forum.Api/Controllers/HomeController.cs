using System.Threading.Tasks;
using Forum.Api.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class HomeController : ControllerBase
    {
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}