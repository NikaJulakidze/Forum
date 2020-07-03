using Forum.Data.Entities;
using Forum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.Repository
{
    public interface IAccountRepository
    {
        (List<ApplicationUser> users, int dataCount) GetAll(UsersFilterModel filter, PagingSettings settings);
    }
}
