using Forum.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public interface IAdminRepository
    {
        void CreateTag(Tag tag);
        void DeleteTag(Tag tag);
        void EditTag(Tag tag);
    }
}
