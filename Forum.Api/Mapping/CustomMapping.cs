using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.Admin;
using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using Forum.Models.Question;
using Forum.Models.Tag;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Forum.Api.Mapping
{
    public class CustomMapping:Profile
    {
        public CustomMapping()
        {
            CreateMap<RegisterRequest, ApplicationUser>();   
            CreateMap<ApplicationUser, RegisterResponse>();
            CreateMap<AddTagModel, Tag>();
            CreateMap<Tag, AddTagModel>();
            CreateMap<IdentityRole, RolesModel>();
            CreateMap<AddQuestionRequest, Question>();
            CreateMap<Question, QuestionModel>()
                .ForMember(dest => dest.QuestionAuthor, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.TagQuestions.Select(x => x.Tag.Title)))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Question, UpDownVoteModel>()
                .ForMember(dest => dest.QuestionRatingPoints, opt => opt.MapFrom(src => src.RatingPoints))
                .ForMember(dest=>dest.UserRatingPoints,opt=>opt.MapFrom(src=>src.User.RatingPoints));
            CreateMap<ApplicationUser, AuthenticationResponse>();
            CreateMap<ApplicationUser, ApplicationUserModel>();
            CreateMap<CreateAnswerRequest, Answer>();
            CreateMap<Answer, AnswerModel>().ForMember(dest=>dest.ApplicationUser,opt=>opt.MapFrom(src=>src.User));
            CreateMap<CreateRole, IdentityRole>();
            CreateMap<ApplicationUser, UserRatingPointsHistory>()
                .ForMember(dest=>dest.Id,opt=>opt.Ignore())
                .ForMember(dest=>dest.UserId,opt=>opt.MapFrom(src=>src.Id));
            CreateMap<ApplicationUser, UserProfileModel>();
        }
    }
}
