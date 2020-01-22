using MetaWeather.Client;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WeatherSearch.Models;

namespace WeatherSearch
{
    /// <summary>
    /// Service class for getting weather forecast info
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private readonly IMetaWeatherClient _metaWeatherClient;
        public WeatherService(IMetaWeatherClient metaWeatherClient)
        {
            _metaWeatherClient = metaWeatherClient;
        }

        /// <summary>
        /// Get WeatherForecasts for a specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<WeatherForecastResult> GetWeatherForecasts(string city)
        {
            try
            {
                WeatherForecastResult result = new WeatherForecastResult();
                List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
                if (!string.IsNullOrWhiteSpace(city))
                {
                    var weatherInfoDetails = await _metaWeatherClient.GetWeatherInfoDetails(city);
                    if (weatherInfoDetails != null && weatherInfoDetails.consolidated_weather != null)
                    {
                        
                        foreach (var weatherInfoDetail in weatherInfoDetails.consolidated_weather.Take(5))
                        {
                            weatherForecasts.Add(new WeatherForecast
                            {
                                Date = Convert.ToDateTime(weatherInfoDetail.applicable_date).ToString("d", CultureInfo.CreateSpecificCulture("en-US"))
                                , Summary = weatherInfoDetail.weather_state_name
                                , TemperatureC = weatherInfoDetail.the_temp
                            });
                        }
                    }
                    return new WeatherForecastResult(city, weatherForecasts);
                }
                return new WeatherForecastResult();
            }
            catch (Exception ex)
            {
                return new WeatherForecastResult("There was an error retrieving weather info.");
            }
        }
    }
}
