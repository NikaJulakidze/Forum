using Forum.Data.Entities;
using Forum.Models.ApplicationUser;
using Forum.Models.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IAccountRepository:IBaseRepository<ApplicationUser>
    {
        Task<(List<ApplicationUser>, int)> GetFilteredUsers(UsersFilterModel filter);
        Task<List<ApplicationUser>> GetHappyBirthDayUsers();
        Task<List<ApplicationUser>> GetTop15UsersThisWeek();
        Task<ApplicationUserTopPosts> TopPosts(string id);
    }
}
