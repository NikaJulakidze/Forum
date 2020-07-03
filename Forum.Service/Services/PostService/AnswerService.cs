using AutoMapper;
using Forum.Data.Uow;

namespace Forum.Service.PostService
{
    public class AnswerService:IAnswerService
    {
        private readonly IAnswerUow _postUow;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerUow postUow,IMapper mapper)
        {
            _postUow = postUow;
            _mapper = mapper;
        }
    }
}
