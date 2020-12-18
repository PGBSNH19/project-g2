using KNet.API.Context;
using KNet.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNet.API.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var context = new AppDbContext();
            var user = new User { FirstName = "Benjamin", LastName = "Ytterström", Email = "bytt@fakemail.se", Password = "Ostbollar123", PhoneNumber = 0123456789 };


            if (!context.Users.Any())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }


            return context.Users.FirstOrDefault().FirstName; 
        }
    }
}
