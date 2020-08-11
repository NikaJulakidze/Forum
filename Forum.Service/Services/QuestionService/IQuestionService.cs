using Forum.Data.Entities;
using Forum.Models;
using Forum.Models.Question;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<Result<QuestionModel>> AskQuestion(AddQuestionRequest model,string id);
        Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId,string voterId);
        Result<QuestionModel> GetQuestionById(int id);
        Task<List<Post>> GetQuestionsByTag(string tagName);
        Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId,string voterId);
    }
}
