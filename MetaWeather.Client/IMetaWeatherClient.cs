using System.Threading.Tasks;

namespace MetaWeather.Client
{
    public interface IMetaWeatherClient
    {
        Task<WeatherInfoDetail> GetWeatherInfoDetails(string city);
    }
}
