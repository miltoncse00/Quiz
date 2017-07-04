using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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

        public Task<CurrentWeather> GetWeather(string country, string city)
        {
            return null;
        }
    }
}
