using FizzBuzz.Data.Repository;
using FizzBuzz.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FizzBuzz.Data.UoW
{
    public interface IUnitOfWork
    {

        //IRepository<Question, int> QuestionRepository { get; }

        //IRepository<QuestionAnswer, int> QuestionAnswerRepository { get; }
        IRepository<TEntity, TKey> GenericRepository<TEntity, TKey>(Type repository = null) where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>;

        void Save();

        Task SaveAsync();

        void Dispose();
    }
}