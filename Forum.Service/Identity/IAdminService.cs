using Forum.Data.Entities;
using Forum.Data.Models;
using Forum.Models.Tag;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAdminService
    {
        Task<Result> CreateRoleAsync(string role);
        Task<Result<AddTagModel>> CreateTagAsync(AddTagModel tagModel);
        Task<PagedList<ApplicationUser>> GetUsersWithPaging(PagingSettings settings);
    }
}
