using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherSearch.Models;

namespace WeatherSearch.Controllers
{
    public class WeatherForecastController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            WeatherForecastResult weatherForecastResult = await _weatherService.GetWeatherForecasts(searchString);
            return View(weatherForecastResult);
        }
    }
}
