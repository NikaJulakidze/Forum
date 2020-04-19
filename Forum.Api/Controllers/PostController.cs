using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Service.Dto;
using Forum.Service.PostService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<PostController> _logger;

        public PostController(IPostService postService,ILogger<PostController> logger)
        {
            _postService = postService;
            _logger = logger;
        }
        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetAction()
        {
            CreatePostDto dto = new CreatePostDto()
            {
                Title = "4223",
                Content = "123"
            };
            var a= await _postService.CreatePostAsync(dto);
            return Ok(a);
        }

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto model)
        {
            _logger.LogInformation("CreatePost Controller");
            var result= await _postService.CreatePostAsync(model);
            return Ok(result);
        }
    }
}