using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class QuestionUow:BaseUow,IQuestionUow
    {
        public QuestionUow(ApplicationDbContext context, IQuestionRepository questionRepository):base(context)
        {
            QuestionRepository = questionRepository;
        }

        public IQuestionRepository QuestionRepository { get; }
    }
}
