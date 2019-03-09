using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public abstract class QuestionAnswer
    {

    }

    public class QuestionAnswerValid : QuestionAnswer
    {
        public string Answer { get; set; }

        public QuestionAnswerValid(string answer)
        {
            Answer = answer;
        }
    }

    public class QuestionAnswerError : QuestionAnswer
    {
        public string Error { get; set; }

        public QuestionAnswerError(string error_message)
        {
            Error = error_message;
        }
    }
}
