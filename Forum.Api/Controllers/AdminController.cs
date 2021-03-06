﻿using System.Threading.Tasks;
using AutoMapper;
using Forum.Data;
using Forum.Data.Repository;
using Forum.Models.Admin;
using Forum.Models.NewFolder;
using Forum.Models.PostType;
using Forum.Models.Tag;
using Forum.Service.Identity;
using Forum.Service.StaticSettings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Forum.Api.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    //[Authorize(Policy =StaticPolicies.ShouldBeAdmin)]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;
        private readonly ITagRepository _tagRepository;

        public AdminController(IAdminService adminService,IMapper mapper,ApplicationDbContext context,IOptionsSnapshot<AppSettings> appSettings, ITagRepository tagRepository)
        {
            _adminService = adminService;
            _mapper = mapper;
            _context = context;
            _appSettings=appSettings.Value;
            _tagRepository = tagRepository;
        }

        [HttpPost("CreateTag")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTags([FromBody] AddTagModel tag)
        {
            var result = _adminService.CreateTagAsync(tag);
            return Ok(result);
        }

        [HttpPost(StaticRoutes.Admin.CreateRole)]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
        public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRole role)
        {
            return CustomResult(await _adminService.CreateRoleAsync(role.Name));
        }

        [HttpPost("CreatePostType")]
        public async Task<IActionResult> CreatePostType([FromBody]CreatePostTypeRequest postType)
        {
            var result=await _adminService.CreatePostTypeAsync(postType);
            return Ok(result);
        }
    }
}