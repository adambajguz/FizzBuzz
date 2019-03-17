using FizzBuzz.Architecture.Entity;
using System;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Entities
{
    public class FizzBuzzHistory<TKey> : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public int InputNumber { get; set; }

        public string Message { get; set; }

        public bool Error { get; set; }

        public string IP { get; set; }
    }
}
