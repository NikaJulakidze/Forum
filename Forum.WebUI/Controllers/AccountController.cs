using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Forum.Models.Account;
using Forum.WebUI.Helpers;
using Forum.WebUI.Services;
using Forum.WebUI.StaticSettings;
using Forum.WebUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;
using Forum.WebUI.Models;
using Microsoft.AspNetCore.Http.Extensions;
using System.Security.Cryptography.X509Certificates;
using System;

namespace Forum.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IApiCallService _apiCall;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemoryCache _memoryCache;

        public AccountController(IApiCallService apiCall,IHttpContextAccessor httpContextAccessor,IMemoryCache memoryCache)
        {
            _apiCall = apiCall;
            _httpContextAccessor = httpContextAccessor;
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult Register()
        //{
        //    var result= _apiCall.GetAsync<List<RolesModel>>(ApiCallStaticRoutes.Account.GetRoles).Result;   
        //    if(result.ResultCode==ApiCallResultCode.UnAuthorized)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    }    
        //    var items = result.Data.Select(i => new SelectListItem { Value = i.Id, Text = i.Name }).ToList();
        //    var registerModel = new RegisterModel();
        //    registerModel.Roles.AddRange(items);

        //    return View(registerModel);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterModel model)
        //{
        //    var result = await _apiCall.PostAsync<ApplicationUserViewModel>(ApiCallStaticRoutes.Account.Register, model);
        //    return CustomResult(result, "Index","Home");
        //}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateUserViewModel model)
        {
            var result = await _apiCall.PostAsync<ApplicationUserViewModel>(ApiCallStaticRoutes.Account.Authenticate, model);
            if (result.Succeeded)
            {
                //_memoryCache.GetOrCreateAsync(result.Data.Id,result.Data.Token,)
                var options = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(2)
                };
                _memoryCache.Set(result.Data.Id, result.Data.Token, options);
                return RedirectToAction("Index", "Home");
            }
            else
                ModelState.FillModelStateErrors(result.NoSuccessResponse.Errors);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {

            var token= Request.Cookies["e8432496-8f9b-4aec-8b8f-51768462a866"];
            var stringcontent = new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
            var httpclient = new HttpClient();
            httpclient.BaseAddress =new System.Uri(ApiCallStaticRoutes.BaseUrl);
            var result=await httpclient.PostAsync(ApiCallStaticRoutes.Account.Test,stringcontent);
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Users(Forum.WebUI.Models.UsersFilterModel filter, int page)
        {
            var test1 = HttpContext.Request.GetEncodedPathAndQuery().Remove(0, 1);

            var request = await _apiCall.GetAsync<ApplicationUserViewModel>(test1);
            return View();
        }
    }
}