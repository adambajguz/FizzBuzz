using FizzBuzz.Architecture.Data.Repository;
using FizzBuzz.Architecture.Data.UoW;
using FizzBuzz.Architecture.Entity;
using FizzBuzz.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Architecture.Architecture.Data.UoW
{
    public class GenericUnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext Context;

        public GenericUnitOfWork(DbContext dbContext)
        {
            this.Context = dbContext;
        }

        private Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<TEntity, TKey> GetRepository<TEntity, TKey>(Type repository = null) where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
        {
            if (Repositories.Keys.Contains(typeof(TEntity)))
                return Repositories[typeof(TEntity)] as IRepository<TEntity, TKey>;

            IRepository<TEntity, TKey> repo = null;
            if (repository != null)
                repo = (IRepository<TEntity, TKey>)Activator.CreateInstance(repository, new object[] { Context });
            else
                repo = new GenericRepository<TEntity, TKey>(Context);

            Repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public void Save()
        {
            Context.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await this.Context.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    Context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
