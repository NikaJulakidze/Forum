using System.Security.AccessControl;
using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Data.Entities;
using Forum.Models.Answer;
using Forum.Service.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [AllowAnonymous]
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerService;
        private readonly ILogger<AnswerController> _logger;

        public AnswerController(IAnswerService answerService,ILogger<AnswerController> logger)
        {
            _answerService = answerService;
            _logger = logger;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateAnswer([FromBody]CreateAnswerRequest answer)
        {
            //_logger.LogInformation("Entered {0} Controller, request is {1}", nameof(CreateAnswer),answer);
            var result=await _answerService.AddAnswerAsync(answer, UserId,Username);
            return CustomGenericResult(result);
        }
    }
}
