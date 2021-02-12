using Forum.Data.Entities;
using Forum.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IQuestionRepository : IBaseRepository<Post>
    {
        Task<(List<Post> questions, int count)> GetPagedQuestions(BaseFilterModel baseFilterModel);
        Post GetQuestionByIdWithIncludes(int id);
        Task<(List<Post>,int)> GetQuestionsByTag(string tagNama);
        Task<Post> GetQuestionWithUserInclude(int questionId);
    }
}
