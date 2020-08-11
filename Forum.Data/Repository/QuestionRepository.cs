using Forum.Data.Entities;
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

        public Post GetQuestionWithUserInclude(int questionId)
        {
            return _entity.Where(x => x.Id == questionId).Include(x => x.User).FirstOrDefault();
        }

        public async Task<(List<Post>, int)> GetQuestionsByTag(string tagNama)
        {
            return (null, 1);
        } 

        public override Task<Post> GetByIdAsync<T>(T id)
        {
            return base.GetByIdAsync(id);
        }


    }
}
