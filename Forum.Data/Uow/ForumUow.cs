using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class ForumUow : BaseUow, IForumUow
    {
        public ForumUow(ApplicationDbContext context, IForumRepository forumRepository):base(context)
        {
            ForumRepository = forumRepository;
        }
        public IForumRepository ForumRepository { get; }
    }
}
