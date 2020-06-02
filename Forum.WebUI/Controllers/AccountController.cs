using System.Threading.Tasks;
using Forum.WebUI.Extensions;
using Forum.WebUI.Helpers;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Forum.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiCallService _apiCall;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IApiCallService apiCall,IHttpContextAccessor httpContextAccessor)
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
            var result = await _apiCall.PostAsync<ApplicationUserViewModel>(ApiCallSettings.Register, model);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
                return View();
        }

        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateUserViewModel model)
        {
            //var result = await _apiCall.PostAsync(ApiCallSettings.Authenticate, model);
            //var response = await result.PostResponseAsync<ApplicationUserViewModel>();
            //if (response is ApplicationUserViewModel) {
            //    var token = (ApplicationUserViewModel)response;
            //    _httpContextAccessor.HttpContext.Response.Cookies.Append(model.Email, token.Token);
            //    return RedirectToAction("Index", "Home"); 
            //}
            return View();
        }
    }
}