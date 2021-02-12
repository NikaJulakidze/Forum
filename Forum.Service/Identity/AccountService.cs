using AutoMapper;
using CommonModels;
using CommonModels.Paging;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;
using Forum.Models.Account;
using Forum.Models.ApplicationUser;
using Forum.Models.Filters;
using Forum.Models.NewFolder;
using Forum.Service.Helpers;
using Forum.Service.Models;
using Forum.Service.Services.MailService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
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
        private readonly AppSettings _appSettings;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHostingEnvironment _env;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRatingPointsHistoryRepository _historyRepository;
        private readonly ILogger<AccountService> _logger;
        private readonly IAccountRepository _accountRepository;

        public AccountService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,
            IMapper mapper,IOptions<AppSettings> options,RoleManager<IdentityRole> roleManager,IHostingEnvironment env,
            IEmailService emailService,IUnitOfWork unitOfWork, IRatingPointsHistoryRepository historyRepository, ILogger<AccountService> logger,IAccountRepository accountRepository) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _appSettings = options.Value;
            _roleManager = roleManager;
            _env = env;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _historyRepository = historyRepository;
            _logger = logger;
            _accountRepository = accountRepository;
        }

        public async Task<Result<RegisterResponse>> RegisterAsync(RegistrationRequestModel model)
        {
            _logger.LogInformation("Entered Register Service...");
            var user = _mapper.Map<ApplicationUser>(model);
            IdentityHelpers.UploadDefaultProfilePhoto(_env.WebRootFileProvider.GetFileInfo("images/Defaultimage.png").PhysicalPath, user);

            _logger.LogInformation("Creating new user");
            user.EmailConfirmed = true;
            var identityResult = await _userManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                var noSuccessMessage = NoSuccessMessage.AddErrors(identityResult.Errors.Select(x => x.Description).ToList());
                _logger.LogError("{0}", noSuccessMessage);
                return Result.BadRequest<RegisterResponse>(noSuccessMessage);
            }

            await _userManager.AddToRoleAsync(user, model.Role);
            _historyRepository.Add(new UserRatingPointsHistory { RatingPoints = user.RatingPoints, User = user });

            _unitOfWork.Commit();
            var response = _mapper.Map<RegisterResponse>(user);

            return Result.Ok(response);
        }


        public async Task<List<ApplicationUser>> GetHappyBirthDayUsers()
        {
            return new List<ApplicationUser>();
        }

        public async Task<Result<AuthenticationResponseModel>> AuthenticateAsync(AuthenticatationRequestModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                var noSuccessMessage = NoSuccessMessage.AddError("Email or password is invalid");
                return Result.BadRequest<AuthenticationResponseModel>(noSuccessMessage);
            }

            var token = await GenerateJWTToken(user);
            
            if (!user.EmailConfirmed && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                await _emailService.SendMail(EmailSendModel.BuildEmailVerificationModel(user, _appSettings, token));
                return Result.BadRequest<AuthenticationResponseModel>(NoSuccessMessage.AddError("Your Email is not confirmed, We've sent you instructions to your mail address"));
            }

            var response = _mapper.Map<AuthenticationResponseModel>(user);

            var identityResult = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

            if (!identityResult.Succeeded)
            {
                var noSuccessMessage = NoSuccessMessage.AddError("Email or password is invalid");
                return Result.BadRequest<AuthenticationResponseModel>(noSuccessMessage);
            }
            
            response.Token = token;
            return Result.Ok(response);
        }

        public async Task<List<RolesModel>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.Where(x => x.Name == "Developer" || x.Name=="Employer").ToListAsync();
            return _mapper.Map<List<RolesModel>>(roles);  
        }

        public async Task<UserProfileModel> GetUserProfile(string id)
        {
            return  await _accountRepository.GetByIdAsync(id);
        }

        public async Task<PagedResult<List<ApplicationUser>>> GetPagedUsersAsync(UsersFilterModel model)
        {
            //var a= PagedResult<List<ApplicationUser>>.CreatePagedResponse(result.Item1,result.Item2,1,5);
            return null;
        }

        public async Task<Result<List<ApplicationUserListingModel>>> GetTop15ThisWeek()
        {
            return Result.Ok(new List<ApplicationUserListingModel>());
        }


        public async Task GiftTop15Users()
        {
        }
       

        private async Task<string> GenerateJWTToken(ApplicationUser user)
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.JwtSettings.Secret);
            
            var userRoles=await _userManager.GetRolesAsync(user);

            //var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                //new Claim(JwtRegisteredClaimNames.GivenName)
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            //claims.AddRange(userClaims.Select(claim => new Claim(claim.Type, claim.Value)));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));

            var expires = DateTime.Now.AddDays(Convert.ToDouble(_appSettings.JwtSettings.Expires));
            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_appSettings.JwtSettings.Issuer, _appSettings.JwtSettings.Audiance, claims, notBefore: DateTime.Now, expires: expires, signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
