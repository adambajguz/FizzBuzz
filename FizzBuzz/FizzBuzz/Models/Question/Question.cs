using System;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Models.Question
{
    public class Question
    {
        public int Number { get; set; }

        private static readonly Tuple<int, string>[] Cases =
        {
            Tuple.Create(3, "fizz"),
            Tuple.Create(5, "buzz"),
            Tuple.Create(7, "wizz"),
        };

        public QuestionAnswer GetAnswer()
        {
            if (Number < 1 || Number > 1000)
                return new QuestionAnswer(Number, "Invalid number! Number should be from 1 to 1000.", true);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in Cases)
                if (Number % item.Item1 == 0)
                    stringBuilder.Append(item.Item2);

            if (stringBuilder.Length == 0)
                return new QuestionAnswer(Number, Number.ToString());

            return new QuestionAnswer(Number, stringBuilder.ToString());
        }
    }

}
