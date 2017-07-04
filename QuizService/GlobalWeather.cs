using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizCommon;
using QuizService.GlobalWeatherService;

namespace QuizService
{
    public class GlobalWeather: IWeatherService
    {
        public Task<string> GetCitiesByCountry(string countryName)
        {
            var globalWeatherSoapClient = new GlobalWeatherSoapClient();
            var citiesByCountryAsync = globalWeatherSoapClient.GetCitiesByCountryAsync(countryName);
         
            return citiesByCountryAsync;
        }

        public async Task<CurrentWeather> GetWeather(string country, string city)
        {
            var globalWeatherSoapClient = new GlobalWeatherSoapClient();
            var currentWeather = await globalWeatherSoapClient.GetWeatherAsync(country, city);
            if (currentWeather == "Data Not Found")
            {
                var weatherApi = new WeatherApi();
                return await  weatherApi.GetWeather(city);
            }
            var serializer = new Serializer();
            var weather = serializer.Deserialize<CurrentWeather>(currentWeather);

            return weather;
        }

        //private async Task<CurrentWeather> GetWeatherFromApi(string country, string city)
        //{
           
        //}
    }

}
