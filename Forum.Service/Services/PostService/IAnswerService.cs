using Forum.Service.Dto;
using Forum.Service.Dto.Post;
using Forum.Service.Models;
using System.Threading.Tasks;

namespace Forum.Service.PostService
{
    public interface IAnswerService
    {
        Task<Result<PostDto>> CreatePostAsync(CreateAnswerDto model);
    }
}