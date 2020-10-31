using Forum.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IQuestionRepository : IBaseRepository<Post>
    {
        Post GetQuestionByIdWithIncludes(int id);
        Task<(List<Post>,int)> GetQuestionsByTag(string tagNama);
        Task<Post> GetQuestionWithUserInclude(int questionId);
    }
}
