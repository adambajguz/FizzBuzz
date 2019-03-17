using FizzBuzz.Architecture.Data.Repository;
using FizzBuzz.Architecture.Data.UoW;
using FizzBuzz.Architecture.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Architecture.Controllers
{

    public abstract class GenericDataController<TEntity, TKey> : Controller where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
    {
        public IUnitOfWork UnitOfWork { get; private set; }

        private readonly Type Repository = null;

        public GenericDataController(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        public GenericDataController(IUnitOfWork unitOfWork, Type repository)
        {
            this.UnitOfWork = unitOfWork;
            this.Repository = repository;
        }

        public IRepository<TEntity, TKey> GetRepository()
        {
            return UnitOfWork.GetRepository<TEntity, TKey>(Repository);
        }

        // GET: api/...
        [HttpGet]
        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await GetRepository().GetAllAsync();
        }

        // GET api/.../{id}
        [HttpGet("{id}")]
        public async Task<TEntity> GetAsync(TKey id)
        {
            return await GetRepository().GetAsync(id);
        }

        // POST api/...
        [HttpPost]
        public async Task PostAsync([FromBody]TEntity entity)
        {
            GetRepository().Create(entity);
            await UnitOfWork.SaveAsync();
        }

        // PUT api/.../{id}
        [HttpPut("{id}")]
        public async Task PutAsync(TKey id, [FromBody]TEntity account)
        {
            TEntity tmp = await GetRepository().GetAsync(id);
            if (tmp == null)
                return;

            account.Created = tmp.Created;
            tmp = account;

            GetRepository().Update(tmp);
            await UnitOfWork.SaveAsync();
        }

        // DELETE api/values/{id}
        [HttpDelete("{id}")]
        public async Task DeleteAsync(TKey id)
        {
            await GetRepository().DeleteAsync(id);
            await UnitOfWork.SaveAsync();
        }
    }
}
