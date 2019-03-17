using System;

namespace FizzBuzz.Models.Question
{
    public class QuestionAnswer
    {
        public int InputNumber { get; set; }

        public string Message { get; set; }

        public bool Error { get; set; }
  
        public QuestionAnswer(int inputNumber, string message, bool error = false)
        {
            this.InputNumber = inputNumber;
            this.Message = message;
            this.Error = error;
        }
    }

}
