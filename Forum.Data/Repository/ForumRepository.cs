using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public class ForumRepository:BaseRepository<Forum.Data.Entities.Tag>,IForumRepository
    {
        public ForumRepository(ApplicationDbContext context):base(context)
        {

        }

    }
}
