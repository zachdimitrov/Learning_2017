using System;

namespace Forum.Data.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}