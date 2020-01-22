using System.Collections.Generic;

namespace WeatherSearch.Models
{
    public class WeatherForecastResult
    {
        public WeatherForecastResult()
        {
            WeatherForecasts = new List<WeatherForecast>();
            WasSearched = false;
            HasResult = false;
        }

        public WeatherForecastResult(string error)
        {
            WeatherForecasts = new List<WeatherForecast>();
            Error = error;
            WasSearched = false;
            HasResult = false;
        }

        public WeatherForecastResult(string city, List<WeatherForecast> weatherForecasts)
        {
            City = city;
            WeatherForecasts = weatherForecasts;
            WasSearched = true;
            HasResult = weatherForecasts.Count > 0;
        }
        public string City { get; set; }
        public List<WeatherForecast> WeatherForecasts { get; set; }
        public bool WasSearched { get; set; }
        public bool HasResult { get; set; }
        public string Error { get; set; }
    }
}
