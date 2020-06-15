using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public class QuestionRepository:BaseRepository<Question>,IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
