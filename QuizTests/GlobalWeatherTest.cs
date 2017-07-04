using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json.Linq;
using QuizApi.Controllers;
using QuizCommon;
using QuizService;

namespace QuizTests
{
    [TestClass]
    public class GlobalWeatherTest
    {
        private IWeatherService _weatherService;
        [TestInitialize]
        public void Initialize()
        {
            _weatherService = new TestWeatherService();
        }
        [TestMethod]
        public async Task PrepeareInput()
        {
          ProfileController controller = new ProfileController(_weatherService);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            var cities = await controller.GetCities("Australia");
            ObjectContent objContent = cities.Content as ObjectContent;
            var citiesCollection = objContent.Value as List<string>;
            var firstOrDefault = citiesCollection.Any(s => s.Contains("Sydney"));
            firstOrDefault.Should().BeTrue();
        }


        [TestMethod]
        public async Task TestGetWeather()
        {
            ProfileController controller = new ProfileController(_weatherService);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            JObject obj = JObject.Parse(@"{country:'United States', city:'San Francisco'}");
            var weather = await controller.GetWeather(obj);
            ObjectContent objContent = weather.Content as ObjectContent;
            var currentWeather = objContent.Value as CurrentWeather;
           
            currentWeather.Wind.Should().Be("36MPH");
        }
        [TestMethod]
        public async Task TestWeatherFromApi()
        {
            string output = @"<current>
                <city id=""2643743"" name=""London"">
                <coord lon = ""-0.13"" lat = ""51.51"" />
                <country > GB </country >
                <sun rise = ""2017-01-30T07:40:36"" set = ""2017 -01-30T16:47:56"" />
                </city >
                <temperature value = ""280.15"" min = ""278.15"" max = ""281.15"" unit = ""kelvin"" />
                <humidity value = ""81"" unit = "" % "" />
                <pressure value = ""1012"" unit = ""hPa"" />
                <wind >
                <speed value = ""4.6"" name = ""Gentle Breeze"" />
                <gusts />
                <direction value = ""90"" code = ""E"" name = ""East"" />
                </wind >
                <clouds value = ""90"" name = ""overcast clouds"" />
                <visibility value = ""10000"" />
                <precipitation mode = ""no"" />
                <weather number = ""701"" value = ""mist"" icon = ""50d"" />
                <lastupdate value = ""2017 -01-30T15:50:00"" />
                </current > ";
           var mock= new Mock<WeatherApi>();
            var valueFunction = Task.Factory.StartNew(() => output);
            mock.Protected().Setup<Task<string>>("GetXML", ItExpr.IsAny<string>()).Returns(valueFunction);
            var currentWeather = await mock.Object.GetWeather("San Francisco");

            currentWeather.Temparature.Should().Be("280.15");
        }
    }
}
