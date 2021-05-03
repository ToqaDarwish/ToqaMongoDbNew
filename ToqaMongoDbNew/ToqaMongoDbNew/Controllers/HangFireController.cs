using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToqaMongoDbNew.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HangFireController : ControllerBase
    {
        [HttpPost]
        public IActionResult Welcoming()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Welcome ,, Starting Bright with this new Day"), Cron.Daily,TimeZoneInfo.Local);
            return Ok("Welcoming is initiated");
        }
    }
}
