using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Forum.WebUI.Helpers;
using Forum.WebUI.Services;
using Forum.WebUI.StaticSettings;
using Forum.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            var result = await _apiCall.PostAsync<ApplicationUserViewModel>(ApiCallStaticRoutes.Register, model);
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
            var result = await _apiCall.PostAsync<ApplicationUserViewModel>(ApiCallStaticRoutes.Authenticate, model);
            if (result.Succeeded)
            {
                Response.Cookies.Append(result.Data.Id, result.Data.Token);
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            var token= Request.Cookies["e8432496-8f9b-4aec-8b8f-51768462a866"];
            var stringcontent = new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
            var httpclient = new HttpClient();
            httpclient.BaseAddress =new System.Uri(ApiCallStaticRoutes.BaseUrl);
            var result=await httpclient.PostAsync(ApiCallStaticRoutes.Test,stringcontent);
            return null;
        }
    }
}