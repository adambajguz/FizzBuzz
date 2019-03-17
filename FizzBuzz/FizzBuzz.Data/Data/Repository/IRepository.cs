using FizzBuzz.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Data.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        void Create(TEntity entity);
        Task DeleteAsync(TKey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }

}
