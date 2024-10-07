using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            Thread.Sleep(1000);

            Console.WriteLine("Database connection finished");

            Thread.Sleep(1000);
            Console.WriteLine("Email send finished");

            Console.WriteLine("All process has been finished");
            sw.Stop();

            return Ok(sw.Elapsed);
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();

            var task1 = new Task<int>(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Database connection finished");
                return 8;
            });

            task1.Start();

            var task2 = new Task(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Email sent!");
            });

            task2.Start();

            Console.WriteLine("A sub proccess while a database connection is executing");

            var result = await task1;
            await task2;

            Console.WriteLine("All process has been finished");

            sw.Stop();

            return Ok(result + " " + sw.Elapsed);
        }
    }
}
