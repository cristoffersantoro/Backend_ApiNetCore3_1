using System;

namespace Backend_ApiNetCore3_1.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
