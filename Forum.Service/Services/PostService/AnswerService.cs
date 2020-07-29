using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models;
using Forum.Models.Answer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public class AnswerService:IAnswerService
    {
        private readonly IAnswerUow _answerUow;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly ITagUow _tagUow;

        public AnswerService(IAnswerUow answerUow,IMapper mapper,UserManager<ApplicationUser> userManager,ApplicationDbContext context,ITagUow tagUow)
        {
            _answerUow = answerUow;
            _mapper = mapper;
            _userManager = userManager;
            _context = context;
            _tagUow = tagUow;
        }

        public async Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request,string id,int questionId)
        {
            var answer= _mapper.Map<Answer>(request);
           
            var user=await _userManager.FindByIdAsync(id);
            var question = _context.Questions.Include(x => x.TagQuestions).ThenInclude(x => x.Tag).First(x=>x.Id==questionId);
            answer.User = user;
            _answerUow.AnswerRepository.Add(answer);
            var tags = _tagUow.TagRepository.GetTagsByNames(question.TagQuestions.Select(x=>x.Tag.Title).ToList());
            var tagAnswers = tags.Select(x => new TagAnswer { Tag = x, Answer = answer });
            _context.TagAnswers.AddRange(tagAnswers);

            await _answerUow.CompleteAsync();

            var result= _mapper.Map<AnswerModel>(answer);
            return Result.Ok(result);
        }
    }
}
