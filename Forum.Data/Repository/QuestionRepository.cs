using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public class QuestionRepository:BaseRepository<Question>,IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context):base(context)
        {

        }

        public Question GetQuestionByIdWithIncludes(int id)
        {
           return _entity.Where(x => x.Id == id)
                .Include(i => i.User)
                .Include(i => i.Answers)
                .ThenInclude(i=>i.User)
                .Include(x=>x.TagQuestions)
                .ThenInclude(x=>x.Tag).FirstOrDefault();
        }

        public Question GetQuestionWithUserInclude(int questionId)
        {
            return _entity.Where(x => x.Id == questionId).Include(x => x.User).FirstOrDefault();
        }

        public override Task<Question> GetByIdAsync<T>(T id)
        {
            return base.GetByIdAsync(id);
        }
    }
}
