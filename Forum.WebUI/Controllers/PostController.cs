using System.Threading.Tasks;
using Forum.WebUI.Models;
using Forum.WebUI.Services;
using Forum.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.WebUI.Controllers
{
    public class PostController : Controller
    {
        private readonly IApiCall _apiCall;

        public PostController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostViewModel model)
        {
            var httpResponse= await _apiCall.PostAsync(ApiCallSettings.CreatePost, model);

            //var result = await httpResponse.PostResponseAsync<CreatePostViewModel>(_apiCall, ApiCallSettings.CreatePost);
            return RedirectToAction("Index", "Home");
        }
    }
}