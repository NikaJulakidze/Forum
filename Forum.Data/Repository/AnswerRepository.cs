using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Data.Repository
{
    public class AnswerRepository:BaseRepository<Post>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context):base(context)
        {

        }

        public List<Post> GetAnswersByPost(int questionId)
        {
            return _entity.Where(x => x.PostTypeId == questionId).Include(x=>x.User).ToList();
        }
    }
}
