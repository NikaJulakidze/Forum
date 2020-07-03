using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.Tag;
using Forum.Service.Dto;
using Forum.Service.Dto.Account;
using Forum.Service.Dto.Post;
using Forum.Service.Dto.Tags;
using Forum.Service.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Api.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<CreateAnswerDto, Answer>();
            CreateMap<Answer, PostDto>();
            CreateMap<RegisterRequest, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<UserAuthenticationRequestDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserAuthenticationResponseDto>().ForMember(x => x.Token, opt => opt.Ignore());
            CreateMap<ApplicationUser, RegisterResponse>();
            CreateMap<AddTagModel, Tag>();
            CreateMap<Tag, AddTagModel>();
            CreateMap<IdentityRole, RolesModel>();
        }
    }
}
