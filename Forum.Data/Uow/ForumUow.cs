using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class ForumUow : BaseUow, IForumUow
    {
        public ForumUow(ApplicationDbContext context, ITagRepository forumRepository):base(context)
        {
            ForumRepository = forumRepository;
        }
        public ITagRepository ForumRepository { get; }
    }
}
