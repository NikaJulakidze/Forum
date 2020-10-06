using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using Forum.Models.PostType;
using Forum.Models.Question;
using Forum.Models.Tag;
using System.Collections.Generic;
using System.Linq;

namespace Forum.Api.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<RegisterRequest, ApplicationUser>();
            CreateMap<ApplicationUser, RegisterResponse>();
            CreateMap<CreatePostTypeRequest, PostType>();
            CreateMap<AddTagModel, Tag>();
            CreateMap<Tag, AddTagModel>();
            CreateMap<Post, QuestionModel>();
            CreateMap<AddQuestionRequest, Post>();
            CreateMap<CreateAnswerRequest, Post>();
            CreateMap<ApplicationUser, ApplicationUserModel>();

            //CreateMap<List<Post>, QuestionModel>()
            //    .ForMember(x=>x.QuestionAuthor,opt=>opt.MapFrom(x=>x.First(x=>x.PostType==1))
            //    .ForMember(x=>x.Tags,opt=>opt.MapFrom(x=>x.First(x=>x.PostTypeId==1).TagPosts.Select(x=>x.Tag.Title)))
            //    .ForMember(x=>x.Answers,opt=>opt.MapFrom(x=>x.;
            //CreateMap<Post, QuestionModel>()
            //    .ForMember(x=>x.Tags,opt=>opt.Ignore())
            //    .ForMember(x=>x.Answers,opt=>opt.Ignore());

            CreateMap<List<Post>, QuestionModel>()
                .ForMember(x => x.Answers, opt => opt.MapFrom(x => x.Where(x => x.PostTypeId == 1)))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.First(x => x.PostTypeId == 2).TagPosts.Select(x => x.Tag.Title)))
                .ForMember(x=>x.Content,opt=>opt.MapFrom(x=>x.First(x=>x.PostTypeId==2).Content));
            CreateMap<Post, AnswerModel>()
                .ForMember(x => x.ApplicationUser, opt => opt.MapFrom(x => x.User));
        }
    }
}
