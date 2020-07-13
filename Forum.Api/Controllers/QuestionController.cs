using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Models.Question;
using Forum.Service.Services.QuestionService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [AllowAnonymous]
    public class QuestionController : BaseController
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _questionService;

        public QuestionController(ILogger<QuestionController> logger,IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionRequest model)
        {
            var result=await _questionService.AskQuestion(model, User.FindFirstValue(ClaimTypes.Email));
            return Ok(result.Data);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetQuestionById(int id)
        {
            var result = _questionService.GetQuestionById(id);
            return CustomGenericResult(result);
        }

        [HttpPut("[action]/{id}")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UpVoteQuestion(int id)
        {
            var result = await _questionService.UpvoteQuestion(id,User.FindFirstValue(ClaimTypes.Email));
            return CustomGenericResult(result);
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> DownVoteQuestion(int id)
        {
            var result = await _questionService.DownVoteQuestion(id,User.FindFirstValue(ClaimTypes.Email));
            return CustomGenericResult(result);
        }

    }
}