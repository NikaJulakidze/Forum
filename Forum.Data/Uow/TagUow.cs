using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class TagUow : BaseUow, ITagUow
    {
        public TagUow(ApplicationDbContext context,ITagRepository tagRepository):base(context)
        {
            this.TagRepository = tagRepository;
        }

        public ITagRepository TagRepository { get; }
    }
}
