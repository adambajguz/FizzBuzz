using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;

namespace FizzBuzz.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public ActionResult<QuestionAnswer> Post(Question question)
        {
            try
            {
                return question.GetAnswer();
            }
            catch (InvalidQuestionNumberException ex)
            {
                return BadRequest(new { error = ex.Message });

            }
        }
    }
}
