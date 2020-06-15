using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public interface IAnswerUow:IBaseUow
    {
        IAnswerRepository AnswerRepository { get; }
    }
}