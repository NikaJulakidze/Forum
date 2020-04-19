using System.Threading.Tasks;

namespace Forum.Data.Uow
{
    public interface IBaseUow
    {
        Task<int> CompleteAsync();
    }
}