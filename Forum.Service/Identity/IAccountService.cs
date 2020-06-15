using Forum.Service.Dto.Account;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public interface IAccountService
    {
        Task<Result<UserAuthenticationResponseDto>> AuthenticateAsync(UserAuthenticationRequestDto dto);
        Task<Result<FirstSetupProfileResponseDto>> FirstSetUpUser(string Username, FirstSetUpProfileRequestDto firstSetUp);
        Task<Result<UserRegistrationResponseDto>> RegisterAsync(UserRegistrationRequestDto model);
    }
}