using FizzBuzz.Data;
using FizzBuzz.Data.UoW;
using FizzBuzz.Models;
using FizzBuzz.Models.Question;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    [Route("api/[controller]")]
    public class FizzBuzzLogController : GenericController<FizzBuzzLog<int>, int>
    {
        public FizzBuzzLogController(IUnitOfWork unitOfWork) : base(unitOfWork, typeof(FizzBuzzLogRepository))
        {

        }
    }
}
