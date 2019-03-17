using System;

namespace FizzBuzz.Entities
{
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }

        DateTime Created { get; set; }

        DateTime Modified { get; set; }

    }
}
