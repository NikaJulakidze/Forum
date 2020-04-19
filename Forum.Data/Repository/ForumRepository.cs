using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public class ForumRepository:BaseRepository<Forum.Data.Entities.Forum>,IForumRepository
    {
        public ForumRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
