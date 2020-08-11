using AutoMapper;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models;
using Forum.Models.NewFolder;
using Forum.Models.PostType;
using Forum.Models.Tag;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Service.Identity
{
    public class AdminService : IAdminService
    {
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAdminUow _uow;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AdminService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,IAdminUow uow,IOptionsSnapshot<AppSettings> appSettings,IMapper mapper) 
        {
            _rolemanager = roleManager;
            _userManager = userManager;
            _uow = uow;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<Result> CreateRoleAsync(string name)
        {
            var identityResult= await _rolemanager.CreateAsync(new IdentityRole { Name = name});
            if (identityResult.Succeeded)
                return Result.Ok();
            return Result.BadRequest(NoSuccessMessage.AddErrors(identityResult.Errors.Select(x => x.Description).ToList()));
        }

        public async Task<Result> CreatePostTypeAsync(CreatePostTypeRequest postTypeRequest)
        {
            var postType = _mapper.Map<PostType>(postTypeRequest);
            await _uow.AdminRepository.CreatePostType(postType);
            await _uow.CompleteAsync();
            return Result.Ok();
        }

        public async Task<Result> BanUsersAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(1));
            return Result.Ok();
        }

        public async Task<Result<AddTagModel>> CreateTagAsync(AddTagModel tagModel)
        {
            var tag = _mapper.Map<Tag>(tagModel);
            _uow.AdminRepository.CreateTag(tag);
            await _uow.CompleteAsync();
            return Result.Ok(_mapper.Map<AddTagModel>(tag));
        }
    }
}
