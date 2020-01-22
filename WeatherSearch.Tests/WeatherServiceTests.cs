using FluentAssertions;
using MetaWeather.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherSearch.Tests
{
    [TestClass]
    public class WeatherServiceTests
    {
        private Mock<IMetaWeatherClient> _metaWeatherClient;

        private IWeatherService GetInjecteWeatherService()
        {
            return new WeatherService(
                _metaWeatherClient.Object
            );
        }

        [TestInitialize]
        public void TestInit()
        {
            _metaWeatherClient = new Mock<IMetaWeatherClient>();
        }

        [TestMethod]
        public async Task Searching_For_A_City_Which_Has_Results_Should_Return_WeatherForecastResult_With_List_Of_WeatherForecasts()
        {
            string city = "los angeles";
            var weatherInfoDetails = new WeatherInfoDetail
            {
                consolidated_weather = new List<ConsolidatedWeather> {
                    new ConsolidatedWeather { }
                    , new ConsolidatedWeather { }
                    , new ConsolidatedWeather { }
                    , new ConsolidatedWeather { }
                    , new ConsolidatedWeather { }
                }
            };

            _metaWeatherClient.Setup(
                mc => mc.GetWeatherInfoDetails(It.Is<string>(s => s == city)))
                .ReturnsAsync(weatherInfoDetails);

            var result = await GetInjecteWeatherService().GetWeatherForecasts(city);

            result.WeatherForecasts.Count.Should().Be(weatherInfoDetails.consolidated_weather.Count);
            result.WeatherForecasts.Count.Should().NotBe(0);
            result.WasSearched.Should().BeTrue();
            result.HasResult.Should().BeTrue();
        }

        [TestMethod]
        public async Task Searching_For_A_City_Which_Has_No_Results_Should_Return_WeatherForecastResult_With_Empty_List_Of_WeatherForecasts()
        {
            string city = "city that does not exist";
            var weatherInfoDetails = new WeatherInfoDetail
            {
                consolidated_weather = new List<ConsolidatedWeather> {
                }
            };

            _metaWeatherClient.Setup(
                mc => mc.GetWeatherInfoDetails(It.Is<string>(s => s == city)))
                .ReturnsAsync(weatherInfoDetails);

            var result = await GetInjecteWeatherService().GetWeatherForecasts(city);

            result.WeatherForecasts.Count.Should().Be(0);
            result.WasSearched.Should().BeTrue();
            result.HasResult.Should().BeFalse();
        }
    }
}
