using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.Answer;
using Forum.Models.PostType;
using Forum.Models.Question;
using Forum.Models.Tag;

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
            CreateMap<Post, QuestionModel>();
        }
    }
}
