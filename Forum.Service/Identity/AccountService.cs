using AutoMapper;
using Forum.Data.Entities;
using Forum.Service.Dto.Account;
using Forum.Service.Helpers;
using Forum.Service.Models;
using Forum.Service.Services.MailService;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        private readonly AppSettings _options;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _env;
        private readonly IEmailService _emailService;

        public AccountService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            IMapper mapper,IOptions<AppSettings> options,RoleManager<IdentityRole> roleManager,IHostingEnvironment env,IEmailService emailService) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _options = options.Value;
            _roleManager = roleManager;
            _env = env;
            _emailService = emailService;
        }

        public async Task<Result<UserRegistrationResponseDto>> RegisterAsync(UserRegistrationRequestDto model)
        {
            var user= _mapper.Map<ApplicationUser>(model);
            IdentityHelpers.UploadDefaultProfilePhoto(_env.WebRootFileProvider.GetFileInfo("images/Defaultimage.png").PhysicalPath, user);


            var identityResult= await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                var noSuccessMessage = NoSuccessMessage.AddErrors(identityResult.Errors.Select(x => x.Description).ToList()); 
                return Result.BadRequest<UserRegistrationResponseDto>(noSuccessMessage);
            }
            await _userManager.AddToRoleAsync(user, "User");
            await _emailService.SendMail(EmailSendModel.BuildEmailVerificationModel(user, _options));
            var response = _mapper.Map<UserRegistrationResponseDto>(user);
            response.Token = await GenerateJWTToken(user);
            return Result.Ok(response);
        }

        public async Task<Result<UserAuthenticationResponseDto>> AuthenticateAsync(UserAuthenticationRequestDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user == null)
            {
                var noSuccessMessage= NoSuccessMessage.AddError("Email or password is invalid");
                return Result.BadRequest<UserAuthenticationResponseDto>(noSuccessMessage);
            }

            if (!user.EmailConfirmed && await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                await _emailService.SendMail(EmailSendModel.BuildEmailVerificationModel(user, _options));
                return Result.BadRequest<UserAuthenticationResponseDto>(NoSuccessMessage.AddError("Your Email is not confirmed, We've sent you instructions to your mail address"));
            }
                
            var response = _mapper.Map<UserAuthenticationResponseDto>(user);
            var identityResult=  await _signInManager.PasswordSignInAsync(user.UserName,dto.Password,false,false);
            if (!identityResult.Succeeded)
            {
                var noSuccessMessage = NoSuccessMessage.AddError("Email or password is invalid");
                return Result.BadRequest<UserAuthenticationResponseDto>(noSuccessMessage);
            }

            response.Token = await GenerateJWTToken(user);
            return Result.Ok(response);
        }

        public async Task<Result<FirstSetupProfileResponseDto>> FirstSetUpUser(string Username, FirstSetUpProfileRequestDto firstSetUp)
        {
            var user = await _userManager.FindByNameAsync(Username);
            if (user == null)
                return Result.BadRequest<FirstSetupProfileResponseDto>(NoSuccessMessage.AddError("Something Went Wrong"));

            await _userManager.AddToRoleAsync(user, firstSetUp.WhoAreYou);
            user.ImageUrl = firstSetUp.ImageUrl == null ? user.ImageUrl : firstSetUp.ImageUrl;
            await _userManager.UpdateAsync(user);

            return Result.Ok(new FirstSetupProfileResponseDto() { ImageUrl=user.ImageUrl,Role=firstSetUp.WhoAreYou});
        }

        public async Task RemoveUserFromRoleAsync(ApplicationUser user,string role)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }

        //public async Task UpdateImageUrl(ApplicationUser user, string imageUrl)
        //{
        //    if (imageUrl == null)
        //        return;
        //    user.ImageUrl = imageUrl;
        //    await _userManager.UpdateAsync(user);
        //}

        private async Task<string> GenerateJWTToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_options.JwtSettings.Secret);

            var claimsList = new List<Claim>();
            
            var role=await _userManager.GetRolesAsync(user);
            var claimesList1 = await _userManager.GetClaimsAsync(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(ClaimTypes.Role,role.SingleOrDefault()),
                new Claim("IsAdmin","True")
            };
            claimsList.AddRange(claimesList1);

            var expires = DateTime.Now.AddSeconds(Convert.ToDouble(_options.JwtSettings.Expires));
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_options.JwtSettings.Issuer, _options.JwtSettings.Audiance, claims, notBefore: DateTime.Now, expires: expires, signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
