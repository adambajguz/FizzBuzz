using FizzBuzz.Architecture.Controllers;
using FizzBuzz.Architecture.Data.UoW;
using FizzBuzz.Data.Repositories;
using FizzBuzz.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FizzBuzz.Controllers
{
    [Route("api/[controller]")]
    public class FizzBuzzHistoryController : GenericDataController<FizzBuzzHistory<int>, int>
    {
        public FizzBuzzHistoryController(IUnitOfWork unitOfWork) : base(unitOfWork, typeof(FizzBuzzLogRepository))
        {

        }

        [HttpDelete("DeleteAll")]
        public async Task DeleteAll(int id)
        {
            await ((FizzBuzzLogRepository)GetRepository()).DeleteAll();
            await UnitOfWork.SaveAsync();
        }
    }
}

