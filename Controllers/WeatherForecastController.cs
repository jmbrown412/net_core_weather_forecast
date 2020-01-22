using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherSearch.Models;

namespace WeatherSearch.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast> {
                new WeatherForecast { Date = DateTime.Now.AddDays(1), Summary = "sunny", TemperatureC = 5 }
                , new WeatherForecast { Date = DateTime.Now.AddDays(2), Summary = "partly cloudy", TemperatureC = 10 }
                , new WeatherForecast { Date = DateTime.Now.AddDays(3), Summary = "sunny", TemperatureC = 12 }
                , new WeatherForecast { Date = DateTime.Now.AddDays(4), Summary = "cloudy", TemperatureC = 11 }
                , new WeatherForecast { Date = DateTime.Now.AddDays(5), Summary = "sunny", TemperatureC = 19 }
            };
            return View(weatherForecasts);
        }
    }
}
