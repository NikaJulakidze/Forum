using AutoMapper;
using Forum.Data.Entities;
using Forum.Models.Account;
using Forum.Models.Answer;
using Forum.Models.ApplicationUser;
using Forum.Models.Enums;
using Forum.Models.PostType;
using Forum.Models.Question;
using Forum.Models.Tag;
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
            CreateMap<Tag, TagListingModel>()
                .ForMember(x => x.TagContent, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.TagTitle, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.TotalQuestionsCount, opt => opt.MapFrom(x=>x.TagPosts.Select(x=>x.Post).Where(x=>x.PostTypeId==(int)PostTypeEnum.Question).Count()));
            CreateMap<Tag, UserTopTags>();
            CreateMap<Post, AnswerModel>()
                .ForMember(x=>x.ApplicationUser,opt=>opt.MapFrom(x=>x.Answers.Select(x=>x.User)));
            CreateMap<AddQuestionRequest, Post>();
            CreateMap<Post, QuestionModel>()
                .ForMember(x=>x.QuestionAuthor,opt=>opt.MapFrom(x=>x.User))
                .ForMember(x=>x.Tags,opt=>opt.MapFrom(x=>x.TagPosts.Select(x=>x.Tag.Title)))
                .ForMember(x=>x.AskedTime,opt=>opt.MapFrom(x=>x.CreatedDate))
                .ForMember(x=>x.Answers,opt=>opt.MapFrom(x=>x.Answers));
            CreateMap<Post, QuestionListingModel>()
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.TagPosts.Select(x => x.Tag.Title)));
            CreateMap<Post, TopPosts>()
                .ForMember(x => x.QuestionTitle, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.PostCreatedTime, opt => opt.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.QuestionTitle, opt => opt.MapFrom(x => (x.PostTypeId == (int)PostTypeEnum.Question ? x.Title : x.Parent.Title)))
                .ForMember(x=>x.PostTypeId,opt=>opt.MapFrom(x=>x.PostTypeId));
            CreateMap<CreateAnswerRequest, Post>();
            CreateMap<Post, AnswerModel>()
                .ForMember(x => x.ApplicationUser, opt => opt.MapFrom(x => x.User));
            CreateMap<Post, QuestionListingModel>()
                .ForMember(x => x.AnswersCount, x => x.MapFrom(x => x.AnswersCount))
                .ForMember(x => x.AskedTime, x => x.MapFrom(x => x.CreatedDate))
                .ForMember(x => x.Tags, x => x.MapFrom(x => x.TagPosts.Select(x => x.Tag.Title)))
                .ForMember(x => x.ViewsCount, x => x.MapFrom(x => x.ViewCount))
                .ForMember(x=>x.OwnerName,x=>x.MapFrom(x=>x.User.UserName));
            CreateMap<ApplicationUser, UserProfileModel>()
                .ForMember(x => x.AnswersCount, opt => opt.MapFrom(x => x.Posts.Count(x => x.PostTypeId == (int)PostTypeEnum.Answer)))
                .ForMember(x => x.QuestionsCount, opt => opt.MapFrom(x => x.Posts.Count(x => x.PostTypeId == (int)PostTypeEnum.Question)))
                .ForMember(x => x.TopPosts, opt => opt.MapFrom(x => x.Posts.OrderByDescending(x => x.RatingPoints)));
        }
    }
}
