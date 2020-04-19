using AutoMapper;
using Forum.Data.Entities;
using Forum.Service.Dto;
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
        }
    }
}
