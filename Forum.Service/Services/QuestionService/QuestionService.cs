using AutoMapper;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Models.Question;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.Services.QuestionService
{
    public class QuestionService:IQuestionService
    {
        private readonly IQuestionUow _questionUow;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionUow questionUow,IMapper mapper)
        {
            _questionUow = questionUow;
            _mapper = mapper;
        }

        public async Task<Result> CreatePostAsync(AddQuestionModel model)
        {
            var question= _mapper.Map<Question>(model);
            
            return null;
        }
    }
}
