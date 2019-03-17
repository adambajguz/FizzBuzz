using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FizzBuzz
{
    public class Program
    {
        // Add-Migration InitialMigration
        // Update-Database
        //or
        // dotnet ef migrations add CreateDatabase --project FizzBuzz
        // dotnet ef database update --project FizzBuzz
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
           return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
    }
}
