using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class PostUow:BaseUow,IPostUow
    {
        public PostUow(ApplicationDbContext context,IPostRepository postRepository):base(context)
        {
            PostRepository = postRepository;
        }
        public IPostRepository PostRepository { get; }
    }
}
