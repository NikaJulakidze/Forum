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
    public class QuestionController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly ILogger<QuestionController> _logger;

        public QuestionController(IPostService postService,ILogger<QuestionController> logger)
        {
            _postService = postService;
            _logger = logger;
        }
        [HttpGet("GetQuestions")]
        public async Task<IActionResult> GetQuestions()
        {
            return Ok();
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