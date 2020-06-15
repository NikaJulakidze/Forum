using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.Data.Repository
{
    public class PostRepository:BaseRepository<Answer>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
