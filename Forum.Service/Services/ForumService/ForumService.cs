using Forum.Data.Uow;

namespace Forum.Service.Services.ForumService
{
    public class ForumService:IForumService
    {
        private readonly IForumUow _forumUow;

        public ForumService(IForumUow forumUow)
        {
            _forumUow = forumUow;
        }
        
    }
}
