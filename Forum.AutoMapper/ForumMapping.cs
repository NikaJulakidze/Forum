using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.ApplicationUser;
using Forum.Models.PostType;
using Forum.Models.Question;
using Forum.Models.Tag;
using System;
using System.Linq;

namespace Forum.AutoMapper
{
    public class ForumMapping:Profile
    {
        public ForumMapping()
        {
            CreateMap<RegistrationRequestModel, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterResponse>();
            CreateMap<ApplicationUser, ApplicationUserModel>();
            CreateMap<AuthenticatationRequestModel, ApplicationUser>();
            CreateMap<ApplicationUser, AuthenticationResponseModel>();
            CreateMap<CreatePostTypeRequest, PostType>();
            CreateMap<AddTagModel, Tag>().ReverseMap();
            CreateMap<AddQuestionRequest, Post>();
            CreateMap<Post, QuestionModel>()
                .ForMember(x=>x.QuestionAuthor,opt=>opt.MapFrom(x=>x.User))
                .ForMember(x=>x.Tags,opt=>opt.MapFrom(x=>x.TagPosts.Select(x=>x.Tag.Title)))
                .ForMember(x=>x.AskedTime,opt=>opt.MapFrom(x=>x.CreatedDate));
            
        }
    }
}
