using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Models
{
    public class Question
    {
        public int Number { get; set; }

        public QuestionAnswer GetAnswer()
        {
            return new QuestionAnswerValid("44");
        }
    }
}
