using System;
using System.Text;

namespace FizzBuzz.Models
{
    public class Question
    {
        public int Number { get; set; }

        public QuestionAnswer GetAnswer()
        {
            if (Number < 1 || Number > 100)
                throw new InvalidQuestionNumberException("Invalid number! Number should be from 1 to 100.");

            StringBuilder stringBuilder = new StringBuilder();

            if (Number % 3 == 0)
                stringBuilder.Append("fizz");

            if (Number % 5 == 0)
                stringBuilder.Append("buzz");

            if (stringBuilder.Length == 0)
                return new QuestionAnswer(Number.ToString());

            return new QuestionAnswer(stringBuilder.ToString());
        }
    }

    class InvalidQuestionNumberException : Exception
    {
        public InvalidQuestionNumberException(string error) : base(error)
        {

        }
    }
}
