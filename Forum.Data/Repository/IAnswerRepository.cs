using Forum.Data.Entities;
using System.Collections.Generic;

namespace Forum.Data.Repository
{
    public interface IAnswerRepository : IBaseRepository<Post>
    {
        List<Post> GetAnswersByPost(int questionId);
    }
}