using FizzBuzz.Architecture.Data.Repository;
using FizzBuzz.Architecture.Entity;
using System;
using System.Threading.Tasks;

namespace FizzBuzz.Architecture.Data.UoW
{
    public interface IUnitOfWork
    {

        //IRepository<Question, int> QuestionRepository { get; }

        //IRepository<QuestionAnswer, int> QuestionAnswerRepository { get; }
        IRepository<TEntity, TKey> GetRepository<TEntity, TKey>(Type repository = null) where TEntity : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>;

        void Save();

        Task SaveAsync();

        void Dispose();
    }
}