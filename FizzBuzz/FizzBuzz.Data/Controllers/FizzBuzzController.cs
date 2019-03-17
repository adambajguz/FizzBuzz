using FizzBuzz.Data;
using FizzBuzz.Data.UoW;
using FizzBuzz.Models;
using FizzBuzz.Models.Question;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FizzBuzz.Data.Controllers
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

        [HttpPost("/api/fizzbuzz")]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            System.Net.IPAddress ipAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress;

            IActionResult result = BadRequest();

            IQuestionResult questionResult = question.GetAnswer();

            bool error = false;

            if (questionResult is QuestionAnswer)
                result = Ok((QuestionAnswer)questionResult);
            else if (questionResult is QuestionError)
            {
                error = true;
                result = BadRequest((QuestionError)questionResult);
            }

            FizzBuzzLog<int> entity = new FizzBuzzLog<int>()
            {
                InputNumber = question.Number,
                Error = error

            };

            UnitOfWork.GenericRepository<FizzBuzzLog<int>, int>().Create(entity);
            await UnitOfWork.SaveAsync();



            return result;
        }
    }
}


