using System;
using System.Collections.Generic;
using Drizzly.Commons;
using Drizzly.Service.Weather.Models;
using Drizzly.Service.Weather.Providers;
using Drizzly.Service.Weather.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;

namespace Drizzly.Service.Weather.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {

        private readonly IConfiguration _configuration;

        public ApiController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/values/5
        [HttpGet("all")]
        public IActionResult Get(int id)
        {
            var test = new OutputFormat();

            var ok = new OpenWeatherMap(_configuration);
            
            var result = ok.GetCurrentWeather(48.0833, 7.3667, "metric");

            Console.WriteLine(((double)result.dt).TimestampToDateTime());

            ok.LastData = ((double) result.dt).TimestampToDateTime();
            
            test.Providers.Add(ok);
            
            test.Temperatures.Add(new CustomTypes.Temperature((double) result.main.temp_min, (double) result.main.temp_max, (double) result.main.temp, CustomTypes.TemperatureUnits.Celsius));
            
            return Json((object) test).ToUnifiedResult();

        }
        
        [HttpGet("test")]
        public IActionResult Get()
        {
          

            var ok = new OpenWeatherMap(_configuration);
            
            var result = ok.GetCurrentWeather(48.0833, 7.3667, "metric");

            return Json((object) result).ToUnifiedResult();

        }
        
    }
}