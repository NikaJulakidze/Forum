using Forum.Data.Uow;
using Forum.Service.Dto;
using Forum.Service.Dto.Post;
using Forum.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Services.ForumService
{
    public class ForumService:IForumService
    {
        private readonly IForumUow _forumUow;

        public ForumService(IForumUow forumUow)
        {
            _forumUow = forumUow;
        }
        public async Task<Result<PostDto>> CreatePostAsync(CreatePostDto model)
        {
            return null;
        }
    }
}
