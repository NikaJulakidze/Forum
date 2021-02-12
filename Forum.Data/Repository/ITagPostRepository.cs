using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public interface ITagPostRepository:IBaseRepository<Tag>
    {
        void AddRange(List<TagPost> tagQuestions);
    }
}
