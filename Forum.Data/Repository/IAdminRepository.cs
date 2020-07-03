using Forum.Data.Entities;
using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IAdminRepository
    {
        void CreateTag(Tag tag);
        void DeleteTag(Tag tag);
        void EditTag(Tag tag);
    }
}
