using CommonModels;
using Forum.Models.Answer;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public interface IAnswerService
    {
        Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request, string userId,string username);
    }
}