using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuizApi.Controllers;
using QuizCommon;

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

            var weather = await controller.GetWeather("United States","San Francisco");
            ObjectContent objContent = weather.Content as ObjectContent;
            var currentWeather = objContent.Value as CurrentWeather;
           
            currentWeather.Wind.Should().Be("36MPH");
        }
    }

    public class TestWeatherService : IWeatherService
    {
        public Task<string> GetCitiesByCountry(string countryName)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var input =
                    @"<NewDataSet> <Table> <Country>Australia</Country> <City>Archerfield Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Amberley Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Alice Springs Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Brisbane Airport M. O</City> </Table> <Table> <Country>Australia</Country> <City>Coolangatta Airport Aws</City> </Table> <Table> <Country>Australia</Country> <City>Cairns Airport</City> </Table> <Table> <Country>Australia</Country> <City>Charleville Airport</City> </Table> <Table> <Country>Australia</Country> <City>Gladstone</City> </Table> <Table> <Country>Australia</Country> <City>Longreach Airport</City> </Table> <Table> <Country>Australia</Country> <City>Mount Isa Amo</City> </Table> <Table> <Country>Australia</Country> <City>Mackay Mo</City> </Table> <Table> <Country>Australia</Country> <City>Oakey Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Proserpine Airport</City> </Table> <Table> <Country>Australia</Country> <City>Rockhampton Airport</City> </Table> <Table> <Country>Australia</Country> <City>Broome Airport</City> </Table> <Table> <Country>Australia</Country> <City>Townsville Amo</City> </Table> <Table> <Country>Australia</Country> <City>Weipa City</City> </Table> <Table> <Country>Australia</Country> <City>Gove Airport</City> </Table> <Table> <Country>Australia</Country> <City>Tennant Creek Airport</City> </Table> <Table> <Country>Australia</Country> <City>Yulara Aws</City> </Table> <Table> <Country>Australia</Country> <City>Albury Airport</City> </Table> <Table> <Country>Australia</Country> <City>Devonport East</City> </Table> <Table> <Country>Australia</Country> <City>Goldstream Aws</City> </Table> <Table> <Country>Australia</Country> <City>East Sale Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Hobart Airport</City> </Table> <Table> <Country>Australia</Country> <City>Launceston Airport</City> </Table> <Table> <Country>Australia</Country> <City>Laverton Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Moorabbin Airport Aws</City> </Table> <Table> <Country>Australia</Country> <City>Mount Gambier Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Mildura Airport</City> </Table> <Table> <Country>Australia</Country> <City>Melbourne Airport</City> </Table> <Table> <Country>Australia</Country> <City>Macquarie Island</City> </Table> <Table> <Country>Australia</Country> <City>Wynyard West</City> </Table> <Table> <Country>Australia</Country> <City>Adelaide Airport</City> </Table> <Table> <Country>Australia</Country> <City>Albany Airport</City> </Table> <Table> <Country>Australia</Country> <City>Broken Hill Patton Street</City> </Table> <Table> <Country>Australia</Country> <City>Ceduna Airport</City> </Table> <Table> <Country>Australia</Country> <City>Derby</City> </Table> <Table> <Country>Australia</Country> <City>Darwin Airport</City> </Table> <Table> <Country>Australia</Country> <City>Bullsbrook Pearce Amo</City> </Table> <Table> <Country>Australia</Country> <City>Edinburgh M. O.</City> </Table> <Table> <Country>Australia</Country> <City>Forrest Airport</City> </Table> <Table> <Country>Australia</Country> <City>Geraldton Airport</City> </Table> <Table> <Country>Australia</Country> <City>Kalgoorlie Boulder Amo</City> </Table> <Table> <Country>Australia</Country> <City>Kununurra Kununurra Aws</City> </Table> <Table> <Country>Australia</Country> <City>Leigh Creek Airport</City> </Table> <Table> <Country>Australia</Country> <City>Learmonth Airport</City> </Table> <Table> <Country>Australia</Country> <City>Meekatharra Airport</City> </Table> <Table> <Country>Australia</Country> <City>Port Hedland Pardoo</City> </Table> <Table> <Country>Australia</Country> <City>Parafield Airport</City> </Table> <Table> <Country>Australia</Country> <City>Belmont Perth Airport</City> </Table> <Table> <Country>Australia</Country> <City>Katherine Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Woomera Aerodrome</City> </Table> <Table> <Country>Australia</Country> <City>Bankstown Airport Aws</City> </Table> <Table> <Country>Australia</Country> <City>Canberra</City> </Table> <Table> <Country>Australia</Country> <City>Coffs Harbour Mo</City> </Table> <Table> <Country>Australia</Country> <City>Cooma</City> </Table> <Table> <Country>Australia</Country> <City>Camden Airport</City> </Table> <Table> <Country>Australia</Country> <City>Dubbo</City> </Table> <Table> <Country>Australia</Country> <City>Norfolk Island Airport</City> </Table> <Table> <Country>Australia</Country> <City>Nowra Ran Air Station</City> </Table> <Table> <Country>Australia</Country> <City>Richmond Aus-Afb</City> </Table> <Table> <Country>Australia</Country> <City>Sydney Airport</City> </Table> <Table> <Country>Australia</Country> <City>Tamworth Airport</City> </Table> <Table> <Country>Australia</Country> <City>Wagga Airport</City> </Table> <Table> <Country>Australia</Country> <City>Williamtown Aerodrome</City> </Table> </NewDataSet>";
                return input;
            });
            return task;
        }

        public Task<CurrentWeather> GetWeather(string country, string city)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var input =
                    @"<CurrentWeather>
                        <Location>SAN FRANCISCO INTERNATIONAL AIRPORT, CA, United State</Location>
                        <Time>Feb 15 2011</Time>
                        <Wind>36MPH</Wind>
                        <Visibility>mostly cloudy</Visibility>
                        <Temparature>13.9 C</Temparature>
                        <DewPoint>6.7 C</DewPoint>
                        <RelativeHumidity>61%</RelativeHumidity>
                        <Pressure>29.84 in. Hg</Pressure>
                        <City>Brisbane Airport M. O</City>
                        <Status>Success</Status>
                        </CurrentWeather>";
                var serializer = new Serializer();
                var currentWeather = serializer.Deserialize<CurrentWeather>(input);
                return currentWeather;
            });
            return task;
        }
    }
}
