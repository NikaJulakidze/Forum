using Forum.Data.Entities;
using Forum.Models;
using Forum.Models.Question;
using Forum.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<Result<QuestionModel>> AskQuestion(AddQuestionRequest model,string id);
        Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId,string voterId);
        Result<Question> GetQuestionById(int id);
        Task<List<Question>> GetQuestionsByTag(string tagName);
        Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId,string voterId);
    }
}
