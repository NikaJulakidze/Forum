using Forum.Data.Entities;
using Forum.Data.Models;
using Forum.Models.Account;
using Forum.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAccountService
    {
        Task<Result<AuthenticationResponse>> AuthenticateAsync(AuthenticatationRequest request);
        Task<List<RolesModel>> GetRolesAsync();
        Task<Result<RegisterResponse>> RegisterAsync(RegisterRequest model);
    }
}