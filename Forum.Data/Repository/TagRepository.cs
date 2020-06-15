using Forum.Data.Entities;

namespace Forum.Data.Repository
{
    public class TagRepository:BaseRepository<Tag>,ITagRepository
    {
        public TagRepository(ApplicationDbContext context):base(context)
        {

        }


    }
}
