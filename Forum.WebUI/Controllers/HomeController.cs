using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Forum.WebUI.Models;
using System.Net.Http;
using Forum.WebUI.Services;

namespace Forum.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiCall _apiCall;

        public HomeController(ILogger<HomeController> logger, IApiCall apiCall)
        {
            _logger = logger;
            _apiCall = apiCall;
        }

        public async Task<IActionResult> Index()
        {
            var aaa=await _apiCall.GetAsync("");
            return View(aaa);
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
