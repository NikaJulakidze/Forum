using Forum.Data.Entities;
using Forum.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Data.Repository
{
    public interface IAccountRepository:IBaseRepository<ApplicationUser>
    {
        Task<(List<ApplicationUser>, int)> GetFilteredUsers(UsersFilterModel filter);
    }
}
