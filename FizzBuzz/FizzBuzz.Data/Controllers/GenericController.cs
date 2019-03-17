using FizzBuzz.Data;
using FizzBuzz.Data.UoW;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{

    public abstract class GenericController<TEntity, TKey> : Controller where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        private readonly Type Repository = null;

        public GenericController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public GenericController(IUnitOfWork unitOfWork, Type repository)
        {
            this.UnitOfWork = unitOfWork;
            this.Repository = repository;
        }

        // GET: api/...
        [HttpGet]
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await UnitOfWork.GenericRepository<TEntity, TKey>(Repository).GetAllAsync();
        }

        // GET api/.../{id}
        [HttpGet("{id}")]
        public async Task<TEntity> GetAsync(TKey id)
        {
            return await UnitOfWork.GenericRepository<TEntity, TKey>(Repository).GetAsync(id);
        }

        // POST api/...
        [HttpPost]
        public async Task PostAsync([FromBody]TEntity entity)
        {
            UnitOfWork.GenericRepository<TEntity, TKey>(Repository).Create(entity);
            await UnitOfWork.SaveAsync();
        }

        // PUT api/.../{id}
        [HttpPut("{id}")]
        public async Task PutAsync(TKey id, [FromBody]TEntity account)
        {
            TEntity tmp = await UnitOfWork.GenericRepository<TEntity, TKey>(Repository).GetAsync(id);
            if (tmp == null)
                return;

            account.Created = tmp.Created;
            tmp = account;

            UnitOfWork.GenericRepository<TEntity, TKey>(Repository).Update(tmp);
            await UnitOfWork.SaveAsync();
        }

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public async Task DeleteAsync(TKey id)
        {
            await UnitOfWork.GenericRepository<TEntity, TKey>(Repository).DeleteAsync(id);
            await UnitOfWork.SaveAsync();
        }
    }
}
