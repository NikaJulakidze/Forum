using Forum.Data.Entities;
using Forum.Models.Question;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return _entity
                .Include(x => x.User)
                .Include(x => x.TagAnswers)
                .ThenInclude(x => x.Answer)
                .First(x => x.Id == id);
        }

        public Question GetQuestionWithUserInclude(int questionId)
        {
            return _entity.Where(x => x.Id == questionId).Include(x => x.User).FirstOrDefault();
        }

        public async Task<(List<Question>, int)> GetQuestionsByTag(string tagNama)
        {
            var tags=_context.Questions.Include(x => x.TagQuestions)
                                       .ThenInclude(x => x.Question)
                                       .Where(x => x.TagQuestions.Any(x => x.Tag.Title.Equals(tagNama)));
        } 

        public override Task<Question> GetByIdAsync<T>(T id)
        {
            return base.GetByIdAsync(id);
        }
    }
}
