using AutoMapper.Configuration;
using Forum.Data.Uow;
using Forum.Service.Identity;
using Forum.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionUow _questionUow;

        public QuestionService(IQuestionUow questionUow)
        {
            _questionUow = questionUow;
        }

        public async Task<Result> CreatePostAsync()
        {
            return null;
        }
    }
}
