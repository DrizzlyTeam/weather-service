using System;
using Drizzly.Commons;
using Drizzly.Service.Weather.Models;
using Drizzly.Service.Weather.Providers;
using Drizzly.Service.Weather.Types;
using Microsoft.AspNetCore.Mvc;

namespace Drizzly.Service.Weather.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {

        // GET api/values/5
        [HttpGet("all")]
        public IActionResult Get(int id)
        {
            var test = new OutputFormat();
            test.Temperatures.Add(new CustomTypes.Temperature(4.5, 10, 20, CustomTypes.TemperatureUnits.Celsius));
            test.Temperatures.Add(new CustomTypes.Temperature(5.5, 11, null, CustomTypes.TemperatureUnits.Fahrenheit));

            foreach (var element in test.Temperatures)
            {
                Console.WriteLine(element.Units);
            }
            
            foreach (var element in test.Providers)
            {
                foreach (var elements in element.Endpoints)
                {
                    Console.WriteLine(elements);
                };
            }

            var ok = new OpenWeatherMap();


            var result = ok.GetJson("Colmar");
            return Json(result).ToUnifiedResult();

        }
        
    }
}