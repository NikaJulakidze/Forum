﻿using AutoMapper;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models;
using Forum.Models.Question;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        public QuestionService(IQuestionUow questionUow,IMapper mapper,ITagUow tagUow,ITagQuestionUow tagQuestionUow,
            ILogger<QuestionService> logger,UserManager<ApplicationUser> userManager)
        {
            _questionUow = questionUow;
            _mapper = mapper;
            _tagUow = tagUow;
            _tagQuestionUow = tagQuestionUow;
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<Result<QuestionModel>> AskQuestion(AddQuestionRequest request,string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var question= _mapper.Map<Question>(request);
            question.User = user;

            var tags = _tagUow.TagRepository.GetTagsByNames(request.Tags);

            if (tags?.Count()==0)
            {
                return Result.BadRequest<QuestionModel>(NoSuccessMessage.AddError(""));
            }

            var tagQuestions = tags.Select(i => new TagQuestion { Question = question, Tag = i }).ToList();
            _questionUow.QuestionRepository.Add(question);
            _tagQuestionUow.TagQuestionRepository.AddRange(tagQuestions);
            await _questionUow.CompleteAsync();

            var test = _questionUow.QuestionRepository.GetQuestionByIdWithIncludes(question.Id);
            var result = _mapper.Map<QuestionModel>(question);
            
            return Result.Ok(result);
        }

        public  Result<QuestionModel> GetQuestionById(int id)
        {
            var result= _questionUow.QuestionRepository.GetQuestionByIdWithIncludes(id);
            if (result == null)
                return Result.NotFound<QuestionModel>(NoSuccessMessage.AddError("Could not find Question"));

            var model = _mapper.Map<QuestionModel>(result);

            return Result.Ok(model);
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
