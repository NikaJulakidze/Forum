using AutoMapper;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models;
using Forum.Models.Answer;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public class AnswerService:IAnswerService
    {
        private readonly IAnswerUow _answerUow;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnswerService(IAnswerUow answerUow,IMapper mapper,UserManager<ApplicationUser> userManager)
        {
            _answerUow = answerUow;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request,string email)
        {
            var answer= _mapper.Map<Answer>(request);
            var user=await _userManager.FindByEmailAsync(email);
            answer.User = user;
            
            _answerUow.AnswerRepository.Add(answer);
            await _answerUow.CompleteAsync();

            var result= _mapper.Map<AnswerModel>(answer);
            return Result.Ok(result);
        }
    }
}
