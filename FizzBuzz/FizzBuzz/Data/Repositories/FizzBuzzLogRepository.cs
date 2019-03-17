using FizzBuzz.Data.Repository;
using FizzBuzz.Entities;
using FizzBuzz.Models.Question;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace FizzBuzz.Data.Repositories
{
    public class FizzBuzzLogRepository : GenericRepository<FizzBuzzHistory<int>, int>
    {
        public FizzBuzzLogRepository(DbContext context) : base(context)
        {

        }

        public void Create(QuestionAnswer result, IPAddress _IPAddress)
        {
            FizzBuzzHistory<int> entity = new FizzBuzzHistory<int>()
            {
                Message = result.Message,
                InputNumber = result.InputNumber,
                Error = result.Error,
                IP = _IPAddress.ToString(),
            };

            Create(entity);
        }

        public async Task DeleteAll()
        {
            var allEntries = await GetAllAsync();

            foreach (var item in allEntries)
                await DeleteAsync(item.Id);
        }
    }
}
