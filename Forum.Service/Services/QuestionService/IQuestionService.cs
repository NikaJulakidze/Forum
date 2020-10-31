using CommonModels;
using Forum.Data.Entities;
using Forum.Models;
using Forum.Models.Question;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<Result<int>> AskQuestion(AddQuestionRequest model,string userId,string Username);
        Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId,string voterId);
        Task<Result<QuestionModel>> GetQuestionById(int id);
        Task<List<Post>> GetQuestionsByTag(string tagName);
        Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId,string voterId);
    }
}
