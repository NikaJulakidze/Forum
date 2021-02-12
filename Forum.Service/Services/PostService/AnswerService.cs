using AutoMapper;
using CommonModels;
using Forum.Data;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;
using Forum.Models.Answer;
using Forum.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public class AnswerService:IAnswerService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAnswerRepository _anwerRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagPostRepository _tagPostRepository;

        public AnswerService(IMapper mapper,UserManager<ApplicationUser> userManager,IAnswerRepository answerRepository,
            ITagRepository tagRepository,ITagPostRepository tagPostRepository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _userManager = userManager;
            _anwerRepository = answerRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _tagPostRepository = tagPostRepository;
        }

        public async Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request,string userId, string username)
        {
            var tags = await _tagRepository.GetTagsByQuestionId(request.QuestionId);

            var post = _mapper.Map<Post>(request);
            post.PostTypeId = (int)PostTypeEnum.Answer;
            post.ParrentId = request.QuestionId;
            post.UserId = userId;
            post.OwnerDisplayName = username;

            var tagAnswer = tags.Select(tag => new TagPost { Tag = tag, Post=post}).ToList();

            _anwerRepository.Add(post);
            _tagPostRepository.AddRange(tagAnswer);
            _unitOfWork.Commit();
            var answerModel = _mapper.Map<AnswerModel>(post);

            return Result.Ok(answerModel);
        }
    }
}
