using Backend_ApiNetCore3_1.Domain.Interfaces;
using Backend_ApiNetCore3_1.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Backend_ApiNetCore3_1.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly dynamic Db;
        protected readonly DbSet<TEntity> DbSet;


        public Repository(Backend_ApiNetCore3_1Context context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }


        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById<TKey>(TKey id) where TKey : IEquatable<TKey>
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove<TKey>(TKey id) where TKey : IEquatable<TKey>
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        /**********************************************************************************************************
        * ATENÇÃO: O template implementa a interface IDisposable porém não implementava
        * completamente os métodos necessários. Abaixo um protótipo da implentação completa
        * mas é preciso avaliar o que utilizar neles e se irá utilizá-los realmente.
        * Estas referências podem ajudar:
        * - https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose?view=netframework-4.8
        * - https://docs.microsoft.com/pt-br/dotnet/api/system.gc.suppressfinalize?view=netframework-4.8
        * - https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/classes-and-structs/destructors
        * 
        **********************************************************************************************************/

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }



    }
}
