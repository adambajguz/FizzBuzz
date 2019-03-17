using FizzBuzz.Data.Repository;
using FizzBuzz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Data.UoW
{
    public class GenericUnitOfWork : IUnitOfWork, IDisposable
    {
        private GenericDbContext Context;

        public GenericUnitOfWork(GenericDbContext dbContext)
        {
            this.Context = dbContext;
        }

        // Słownik będzie używany do sprawdzania instancji repozytoriów
        private Dictionary<Type, object> Repositories = new Dictionary<Type, object>();

        public IRepository<TEntity, TKey> GenericRepository<TEntity, TKey>(Type repository = null) where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
        {
            // Jeżeli instancja danego repozytorium istnieje - zostanie zwrócona
            if (Repositories.Keys.Contains(typeof(TEntity)) == true)
                return Repositories[typeof(TEntity)] as IRepository<TEntity, TKey>;

            IRepository<TEntity, TKey> repo = null;
            if (repository != null)
                repo = (IRepository<TEntity, TKey>)Activator.CreateInstance(repository);
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
