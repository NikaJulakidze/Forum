using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        void Commit();
    }
}
