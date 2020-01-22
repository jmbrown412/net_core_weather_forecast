using System;

namespace WeatherSearch.Models
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public double TemperatureC { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        public string Summary { get; set; }
    }
}
