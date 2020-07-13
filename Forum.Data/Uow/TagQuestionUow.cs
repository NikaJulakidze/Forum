using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class TagQuestionUow:BaseUow,ITagQuestionUow
    {
        public TagQuestionUow(ApplicationDbContext context,ITagQuestionRepository tagQuestionRepository):base(context)
        {
            TagQuestionRepository = tagQuestionRepository;
        }
        public ITagQuestionRepository TagQuestionRepository { get; }
    }
}
