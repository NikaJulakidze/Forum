using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Models.Question;
using Forum.Service.Services.QuestionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _questionService;

        public QuestionController(ILogger<QuestionController> logger,IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> AddQuestion([FromBody] AddQuestionModel model)
        {
            return Ok();
        }
    }
}