using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            return BadRequest(question.GetAnswer());
            return question.GetAnswer();
        }
    }
}
