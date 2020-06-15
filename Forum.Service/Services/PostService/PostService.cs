using AutoMapper;
using Forum.Data.Entities;
using Forum.Data.Uow;
using Forum.Service.Dto;
using Forum.Service.Dto.Post;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public class PostService:IPostService
    {
        private readonly IPostUow _postUow;
        private readonly IMapper _mapper;

        public PostService(IPostUow postUow,IMapper mapper)
        {
            _postUow = postUow;
            _mapper = mapper;
        }

        public async Task<Result<PostDto>> CreatePostAsync(CreatePostDto model)
        {
            var result = new Result<PostDto>();

            var post = _mapper.Map<Answer>(model);
            _postUow.PostRepository.Add(post);
            await _postUow.CompleteAsync();
            result.Data = _mapper.Map<PostDto>(post);
            return result;
        }
    }
}
