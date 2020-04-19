using Forum.Data.Repository;

namespace Forum.Data.Uow
{
    public interface IPostUow:IBaseUow
    {
        IPostRepository PostRepository { get; }
    }
}