using System.Threading.Tasks;
using Forum.WebUI.Extensions;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Forum.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiCall _apiCall;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IApiCall apiCall,IHttpContextAccessor httpContextAccessor)
        {
            _apiCall = apiCall;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _apiCall.PostAsync(ApiCallSettings.Register, model);
            var response = await result.PostResponseAsync<ApplicationUserViewModel>();
            if (response is ApplicationUserViewModel)
                return RedirectToAction("Index", "Home");
            else
                return View("Error", (ErrorViewModel)response);
        }

        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateUserViewModel model)
        {
            var result = await _apiCall.PostAsync(ApiCallSettings.Authenticate, model);
            var response = await result.PostResponseAsync<ApplicationUserViewModel>();
            if (response is ApplicationUserViewModel) {
                var token = (ApplicationUserViewModel)response;
                _httpContextAccessor.HttpContext.Response.Cookies.Append(model.Email, token.Token);
                return RedirectToAction("Index", "Home"); 
            }
            return View("Error", (ErrorViewModel)response);
        }
    }
}