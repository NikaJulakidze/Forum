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
        Task<Result<QuestionModel>> AskQuestion(AddQuestionRequest model,string email);
        Task<Result<UpDownVoteModel>> DownVoteQuestion(int questionId,string voterId);
        Result<QuestionModel> GetQuestionById(int id);
        Task<Result<UpDownVoteModel>> UpvoteQuestion(int questionId,string voterId);
    }
}
