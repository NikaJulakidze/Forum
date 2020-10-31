using AutoMapper;
using CommonModels;
using Forum.Data.Entities;
using Forum.Data.Repository;
using Forum.Data.UnitOfWork;
using Forum.Models.NewFolder;
using Forum.Models.PostType;
using Forum.Models.Tag;
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
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminRepository _adminRepository;

        public AdminService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager,
            IOptionsSnapshot<AppSettings> appSettings,IMapper mapper, ITagRepository tagRepository,IUnitOfWork unitOfWork,IAdminRepository adminRepository) 
        {
            _rolemanager = roleManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _adminRepository = adminRepository;
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
            await _adminRepository.CreatePostType(postType);
            _unitOfWork.Commit();
            return Result.Ok();
        }

        public async Task<Result> BanUsersAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddDays(1));
            return Result.Ok();
        }

        public Result<AddTagModel> CreateTagAsync(AddTagModel tagModel)
        {
            var tag = _mapper.Map<Tag>(tagModel);
            _tagRepository.Add(tag);
             _unitOfWork.Commit();
            return Result.Ok(_mapper.Map<AddTagModel>(tag));
        }
    }
}
