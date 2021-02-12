using System;
using System.Threading.Tasks;

namespace Forum.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
        Task CommitAsync();
    }
}
