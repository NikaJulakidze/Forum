using Forum.Data.Entities;
using Forum.Models;
using Forum.Models.Answer;
using Forum.Service.Models;
using System.Security;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public interface IAnswerService
    {
        Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request, string id,int questionId);
    }
}