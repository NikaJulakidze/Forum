using AutoMapper;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models;
using Forum.Models.Answer;
using Forum.Models.Filters;
using Forum.Models.Question;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionUow _questionUow;
        private readonly ITagUow _tagUow;
        private readonly ITagQuestionUow _tagQuestionUow;
        private readonly ILogger<QuestionService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public QuestionService(IQuestionUow questionUow,IMapper mapper,ITagUow tagUow,ITagQuestionUow tagQuestionUow,
            ILogger<QuestionService> logger,UserManager<ApplicationUser> userManager,ApplicationDbContext context)
        {
            _questionUow = questionUow;
            _mapper = mapper;
            _tagUow = tagUow;
            _tagQuestionUow = tagQuestionUow;
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<Result<QuestionModel>> AskQuestion(AddQuestionRequest request,string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogError("Question with id {0} not found",id);
                return Result.BadRequest<QuestionModel>(NoSuccessMessage.AddError("Something Went Wrong"));
            }

            var question= _mapper.Map<Post>(request);
            question.User = user;
            question.PostTypeId = 2;
            question.OwnerDisplayName = user.UserName;
            
            var tags = _tagUow.TagRepository.GetTagsByNames(request.Tags);

            if (tags?.Count()==0)
            {
                return Result.BadRequest<QuestionModel>(NoSuccessMessage.AddError(""));
            }

            var tagQuestions = tags.Select(i => new TagPost {Post=question, Tag = i }).ToList();

            _questionUow.QuestionRepository.Add(question);
            _tagQuestionUow.TagQuestionRepository.AddRange(tagQuestions);
            await _questionUow.CompleteAsync();

            var result = _mapper.Map<QuestionModel>(question);
            
            return Result.Ok(result);
        }

        public  Result<QuestionModel> GetQuestionById(int id)
        {
            var posts = _context.Posts.Include(x=>x.TagPosts).ThenInclude(x=>x.Tag).Include(x=>x.User).Where(x => x.Id == id || x.ParrentId==id).ToList();
            var question = posts.SingleOrDefault(x => x.Id == id);
            if (question == null)
                return Result.NotFound<QuestionModel>(NoSuccessMessage.AddError("Could not find Question"));

            question.ViewCount += 1;
            _questionUow.QuestionRepository.Update(question);
            _questionUow.CompleteAsync();
            var aaaaaaaaa = _mapper.Map<QuestionModel>(posts);

            return Result.Ok(aaaaaaaaa);
        }

        public async Task<List<Post>> GetQuestionsByTag(string tagName)
        {
            var (aaa,aaaaa)=  await _questionUow.QuestionRepository.GetQuestionsByTag(tagName);
            return null;
        }

        public async Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId, string voterId)
        {
            var question= _questionUow.QuestionRepository.GetQuestionWithUserInclude(questionId);

            if (question.UserId == voterId)
                return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("You cannot upvote your own question"));
            //if (question.User.RatingPoints < 15)
            //    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("Your Rating Points must be atleast 15"));

            question.RatingPoints += 1;
            question.User.RatingPoints += 1;

            await _userManager.UpdateAsync(question.User);
            _questionUow.QuestionRepository.Update(question);
            await _questionUow.CompleteAsync();

            return Result.Ok(_mapper.Map<UpDownVoteModel>(question));
        }

        public async Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId, string voterId)
        {
            var question = _questionUow.QuestionRepository.GetQuestionWithUserInclude(questionId);

            if (question.UserId == voterId)
                return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("You cannot downvote your own question"));
            //if (question.User.RatingPoints < 15)
            //    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("Your Rating Points must be atleast 15"));

            question.RatingPoints -= 1;
            question.User.RatingPoints -= 1;

            await _userManager.UpdateAsync(question.User);
            _questionUow.QuestionRepository.Update(question);
            await _questionUow.CompleteAsync();

            return Result.Ok(_mapper.Map<UpDownVoteModel>(question));
        }
    }
}
