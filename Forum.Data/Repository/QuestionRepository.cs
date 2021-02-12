using AutoMapper.QueryableExtensions;
using Forum.Data.Entities;
using Forum.Data.Extensions;
using Forum.Models.Enums;
using Forum.Models.Filters;
using Forum.Models.Question;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class QuestionRepository:BaseRepository<Post>,IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context):base(context)
        {

        }


        public Post GetQuestionByIdWithIncludes(int id)
        {
            return null;
        }

        public async Task<(List<Post>, int)> GetPagedQuestions(BaseFilterModel baseFilterModel)
        {
            var count = await _entity.CountAsync();
            var result = await _entity.AsNoTracking()
                .Where(x => x.PostTypeId == (int)PostTypeEnum.Question)
                .Include(x => x.User)
                .Include(x => x.TagPosts)
                .ThenInclude(x => x.Tag)
                .SkipAndTake(baseFilterModel.PageNumber, 10).ToListAsync();
            return (result, count);
        }

        public async Task<Post>GetQuestionWithUserInclude(int questionId)
        {
            return await _entity.Where(x => x.Id == questionId)
                .Include(x=>x.User)
                .Include(x=>x.TagPosts).ThenInclude(x=>x.Tag)
                .Include(x => x.Answers).ThenInclude(x=>x.User).FirstOrDefaultAsync();
        }

        public async Task<(List<Post>, int)> GetQuestionsByTag(string tagNama)
        {
            return (null, 1);
        } 

        private IQueryable<Post> FilterPosts(IQueryable<Post> posts, BaseFilterModel baseFilter)
        {
            return null;
        }
    }
}
