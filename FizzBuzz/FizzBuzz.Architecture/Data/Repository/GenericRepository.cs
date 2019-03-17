using FizzBuzz.Architecture.Data.Repository;
using FizzBuzz.Architecture.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Data.Repository
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        protected DbContext dbContext;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContext context)
        {
            this.dbContext = context;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await dbSet.ToListAsync();

            return entities;
        }

        public void Create(TEntity entity)
        {
            entity.Created = DateTime.UtcNow;
            entity.Modified = DateTime.UtcNow;
            dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.Modified = DateTime.UtcNow;
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public async Task DeleteAsync(TKey id)
        {
            var entity = await this.GetAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }
    }
}
