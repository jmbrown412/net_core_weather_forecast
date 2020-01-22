using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherSearch.Models;

namespace WeatherSearch
{
    public interface IWeatherService
    {
        Task<WeatherForecastResult> GetWeatherForecasts(string city);
        
    }
}
