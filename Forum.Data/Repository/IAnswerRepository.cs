using Forum.Data.Entities;
using System.Collections.Generic;

namespace Forum.Data.Repository
{
    public interface IAnswerRepository : IBaseRepository<Answer>
    {
        List<Answer> GetAnswersByPost(int questionId);
    }
}