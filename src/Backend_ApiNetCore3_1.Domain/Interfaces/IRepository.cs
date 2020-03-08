using System;
using System.Linq;

namespace Backend_ApiNetCore3_1.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class

    {
        void Add(TEntity obj);
        TEntity GetById<TKey>(TKey id) where TKey : IEquatable<TKey>;
        IQueryable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove<TKey>(TKey id) where TKey : IEquatable<TKey>;
        int SaveChanges();
    }
}
