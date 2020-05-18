using AutoMapper;
using Forum.Data.Entities;
using Forum.Service.Dto.Account;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly JwtSettings _options;

        public AccountService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            IMapper mapper,IOptions<JwtSettings> options) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _options = options.Value;
        }

        public async Task<Result<UserRegistrationResponseDto>> RegisterAsync(UserRegistrationDto model)
        {
            Result<UserRegistrationResponseDto> result = new Result<UserRegistrationResponseDto>();
            var user= _mapper.Map<ApplicationUser>(model);
            var identityResult= await _userManager.CreateAsync(user, model.Password);
            if (!identityResult.Succeeded)
            {
                result.AddErrors(identityResult.Errors.Select(x => x.Description));
                return result;
            }
            result.Data = _mapper.Map<UserRegistrationResponseDto>(user);
            return result;
        }

        public async Task<Result<UserAuthenticationResponseDto>> AuthenticateAsync(UserAuthenticationRequestDto dto)
        {
            var result = new Result<UserAuthenticationResponseDto>();

            var user = await _userManager.FindByEmailAsync(dto.Email);
            var jwtToken = GenerateJWTToken(user);
            var response = _mapper.Map<UserAuthenticationResponseDto>(user);
            var identityResult=  await _signInManager.PasswordSignInAsync(user.UserName,dto.Password,false,false);
            if (!identityResult.Succeeded)
            {
                result.AddError("Email or Password is Invalid");
                return result;
            }

            response.Token = jwtToken;
            result.Data = response;
            return result;
        }

        private string GenerateJWTToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
            };
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_options.Expires));
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_options.Issuer, _options.Audiance, claims, notBefore: DateTime.Now, expires: expires, signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
