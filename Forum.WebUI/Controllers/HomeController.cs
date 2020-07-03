using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Microsoft.AspNetCore.Http;
using Forum.WebUI.ViewModels;
using Forum.WebUI.StaticSettings;

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

        public async Task<IActionResult> Index()
        {
            UsersFilterModel usersFilter = new UsersFilterModel();
            usersFilter.Role = "test";
            //usersFilter.SearchValue = "testsearch";
            //var result= await _apiCall.GetAsync<TestViewModel>(ApiCallStaticRoutes.GetImage);
            //_httpContextAccessor.HttpContext.Response.Cookies.Append("Key", "This is my cookie!!!!");
            return View(usersFilter);
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
