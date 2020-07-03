using Forum.Data.Entities;
using Forum.Data.Helpers;
using Forum.Data.Models;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Data.Repository
{
    public class AccountRepository : BaseRepository<ApplicationDbContext>, IAccountRepository
    {

        public AccountRepository(ApplicationDbContext context):base(context)
        {

        }

        public (List<ApplicationUser> users,int dataCount)GetAll(UsersFilterModel filter, PagingSettings settings)
        {
            //var users = _context.ApplicationUsers.AsNoTracking();
            //var filteredUsers= FIlterHelper.GetFilteredUsers(users, filter);

            // var result=filteredUsers.Skip((settings.CurrentPage - 1) * settings.PerPage)
            //    .Take(settings.PerPage);

            //return (result.ToList() ,users.Count());
            return (null, 1);
        }
    }
}
