using Forum.Data.Entities;
using Forum.Models;
using Forum.Models.Account;
using Forum.Models.ApplicationUser;
using Forum.Models.Filters;
using Forum.Models.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAccountService
    {
        Task<Result<AuthenticationResponse>> AuthenticateAsync(AuthenticatationRequest request);
        Task<List<ApplicationUser>> GetHappyBirthDayUsers();
        Task<PagedResult<List<ApplicationUser>>> GetPagedUsersAsync(UsersFilterModel model);
        Task<List<RolesModel>> GetRolesAsync();
        Task<Result<List<ApplicationUserListingModel>>> GetTop15ThisWeek();
        Task<UserProfileModel> GetUserProfile(string id);
        Task GiftTop15Users();
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest model);
    }
}