using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Forum.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiCallService _apiCall;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger, IApiCallService apiCall,IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _apiCall = apiCall;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<JsonResult> Index()
        {
           
            return new JsonResult("");
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View();
        }
    }
}
