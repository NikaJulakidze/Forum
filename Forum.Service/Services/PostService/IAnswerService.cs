using Forum.Models;
using Forum.Models.Answer;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public interface IAnswerService
    {
        Task<Result<AnswerModel>> AddAnswerAsync(CreateAnswerRequest request, string email);
    }
}