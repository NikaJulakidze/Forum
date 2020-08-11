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
            var user = await _userManager.FindByIdAsync(id);
            var tags = _context.TagPosts.Where(x => x.PostId == questionId).Select(x => x.Tag).ToList();
            //var test= tags.Select(x => x.Tag).ToList();
            var post = new Post();
            post.AnswersCount += 1;
            post.Content = request.Content;
            post.PostTypeId = 1;
            post.ParrentId = questionId;
            post.User = user;
            post.RatingPoints += 1;
            var tagAnswer = tags.Select(x => new TagPost { Tag = x, Post=post}).ToList();
            //post.TagPosts = tagAnswer;
            var tagPost = new TagPost
            {
                Tag=tags.First(),
                Post = post
            };
            post.OwnerDisplayName = user.UserName;
            await _context.AddAsync(post);
            await _context.AddRangeAsync(tagAnswer);
            await _context.SaveChangesAsync();
            return Result.Ok(new AnswerModel());
        }
    }
}
