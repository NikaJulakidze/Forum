using AutoMapper;
using CommonModels;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;
using Forum.Models.Enums;
using Forum.Models.Question;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public class QuestionService:IQuestionService
    {
        private readonly ILogger<QuestionService> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ITagQuestionRepository _tagQuestionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IMapper mapper,ILogger<QuestionService> logger,UserManager<ApplicationUser> userManager,
            ITagRepository tagRepository, IQuestionRepository questionRepository, ITagQuestionRepository tagQuestionRepository,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
            _tagRepository = tagRepository;
            _questionRepository = questionRepository;
            _tagQuestionRepository = tagQuestionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> AskQuestion(AddQuestionRequest request, string userId,string Username)
        {
            var question = _mapper.Map<Post>(request);
            question.UserId = userId;
            question.PostTypeId =(int)PostTypeEnum.Question;
            question.OwnerDisplayName = Username;

            var tags = _tagRepository.GetTagsByNames(request.Tags);

            if (tags?.Count() == 0)
            {
                return Result.BadRequest<int>(NoSuccessMessage.AddError(""));
            }

            var tagQuestions = tags.Select(i => new TagPost { Post = question, Tag = i }).ToList();

            _questionRepository.Add(question);
            _tagQuestionRepository.AddRange(tagQuestions);
            _unitOfWork.Commit();

            return Result.Ok(question.Id);
        }

        public async Task<Result<QuestionModel>> GetQuestionById(int id)
        {
            var question = await _questionRepository.GetQuestionWithUserInclude(id);
            if (question == null)
                return Result.NotFound<QuestionModel>(NoSuccessMessage.AddError("Not Found"));
            question.ViewCount++;
            _unitOfWork.Commit();
            var questionModel = _mapper.Map<Post, QuestionModel>(question);
            return Result.Ok(questionModel);
        }

        public async Task<List<Post>> GetQuestionsByTag(string tagName)
        {
            return null;
        }

        public async Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId, string voterId)
        {
            //var question= _questionUow.QuestionRepository.GetQuestionWithUserInclude(questionId);

            //if (question.UserId == voterId)
            //    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("You cannot upvote your own question"));
            //if (question.User.RatingPoints < 15)
            //    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("Your Rating Points must be atleast 15"));

            //question.RatingPoints += 1;
            //question.User.RatingPoints += 1;

            //await _userManager.UpdateAsync(question.User);
            //_questionUow.QuestionRepository.Update(question);
            //await _questionUow.CompleteAsync();

            return Result.Ok(new UpDownVoteModel());
        }

        public async Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId, string voterId)
        {
            //var question = _questionUow.QuestionRepository.GetQuestionWithUserInclude(questionId);

            //if (question.UserId == voterId)
            //    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("You cannot downvote your own question"));
            ////if (question.User.RatingPoints < 15)
            ////    return Result.BadRequest<UpDownVoteModel>(NoSuccessMessage.AddError("Your Rating Points must be atleast 15"));

            //question.RatingPoints -= 1;
            //question.User.RatingPoints -= 1;

            //await _userManager.UpdateAsync(question.User);
            //_questionUow.QuestionRepository.Update(question);
            //await _questionUow.CompleteAsync();

            return Result.Ok(new UpDownVoteModel());
        }
    }
}
