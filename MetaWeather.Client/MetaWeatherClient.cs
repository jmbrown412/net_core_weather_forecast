using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MetaWeather.Client
{
    public class MetaWeatherClient : IMetaWeatherClient
    {
        private readonly RestClient _restClient;
        public MetaWeatherClient(string url)
        {
            _restClient = new RestClient(url);
            _restClient.Timeout = -1;
        }
        public async Task<WeatherInfoDetail> GetWeatherInfoDetails(string city)
        {
            var cityInfoDetails = await GetLocationId(city);

            // TODO - Implement functionality when multiple results come back for a city search
            if (cityInfoDetails.Count == 0 || cityInfoDetails.Count > 1)
            {
                return new WeatherInfoDetail();
            }

            // Get forecast for city
            string resource = $"/api/location/{cityInfoDetails[0].woeid}";
            var request = new RestRequest(resource, Method.GET);
            IRestResponse response = await _restClient.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<WeatherInfoDetail>(response.Content);
        }

        private async Task<List<CityInfoDetail>> GetLocationId(string city)
        {
            string resource = $"/api/location/search?query={city}";
            var request = new RestRequest(resource, Method.GET);
            IRestResponse response = await _restClient.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<List<CityInfoDetail>>(response.Content);
        }
    }
}
