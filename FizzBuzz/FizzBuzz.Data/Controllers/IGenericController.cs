using FizzBuzz.Data;
using FizzBuzz.Data.UoW;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    interface IGenericController<TEntity, TKey> where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        IUnitOfWork UnitOfWork { get; }


        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(int id);

        Task PostAsync([FromBody]TEntity question);
        Task PutAsync(int id, [FromBody]TEntity account);

        Task DeleteAsync(int id);
    }
}
