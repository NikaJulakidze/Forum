using AutoMapper;
using Forum.Data.Entities;
using Forum.Service.Dto;
using Forum.Service.Dto.Account;
using Forum.Service.Dto.Post;
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
            CreateMap<CreatePostDto, Post>();
            CreateMap<Post, PostDto>();
            CreateMap<UserRegistrationDto, ApplicationUser>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            CreateMap<UserAuthenticationRequestDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserAuthenticationResponseDto>().ForMember(x => x.Token, opt => opt.Ignore());
        }
    }
}
