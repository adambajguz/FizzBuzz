using FizzBuzz.Architecture.Data.UoW;
using FizzBuzz.Data.Repositories;
using FizzBuzz.Entities;
using FizzBuzz.Models.Question;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : Controller
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        private IHttpContextAccessor _accessor;

        public FizzBuzzController(IHttpContextAccessor accessor, IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
            this._accessor = accessor;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            QuestionAnswer questionResult = question.GetAnswer();

            FizzBuzzLogRepository fizzBuzzLogRepository = (FizzBuzzLogRepository)UnitOfWork.GetRepository<FizzBuzzHistory<int>, int>(typeof(FizzBuzzLogRepository));

            IPAddress ipAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress;

            fizzBuzzLogRepository.Create(questionResult, ipAddress);
            await UnitOfWork.SaveAsync();

            if (questionResult.Error)
                return BadRequest(new { error = questionResult.Message });

            return Ok(new { number = questionResult.Message });
        }
    }
}


