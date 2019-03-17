using System;

namespace FizzBuzz.Architecture.Entity
{
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }

        DateTime Created { get; set; }

        DateTime Modified { get; set; }

    }
}
