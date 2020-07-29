using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        Question GetQuestionByIdWithIncludes(int id);
        Task<(List<Question>,int)> GetQuestionsByTag(string tagNama);
        Question GetQuestionWithUserInclude(int questionId);
    }
}
