using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Api.Attributes;
using Forum.Data.Entities;
using Forum.Models.Answer;
using Forum.Service.PostService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [ModelStateValidation]
    [AllowAnonymous]
    public class AnswerController : BaseController
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        [HttpPost("[action]/{questionId}")]
        public async Task<IActionResult> CreateAnswer([FromBody]CreateAnswerRequest answer,int questionId)
        {
            var result=await _answerService.AddAnswerAsync(answer, UserId,questionId);
            return Ok(result);
        }
    }
}
