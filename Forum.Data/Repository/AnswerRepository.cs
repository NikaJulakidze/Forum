using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Data.Repository
{
    public class AnswerRepository:BaseRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
