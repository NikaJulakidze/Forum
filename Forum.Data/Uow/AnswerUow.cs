using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public class AnswerUow:BaseUow,IAnswerUow
    {
        public AnswerUow(ApplicationDbContext context,IAnswerRepository answerRepository):base(context)
        {
            AnswerRepository = answerRepository;
        }
        public IAnswerRepository AnswerRepository{ get; }
    }
}
