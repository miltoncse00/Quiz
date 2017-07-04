using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizCommon
{
    public interface IWeatherService
    {
        Task<List<string>> GetCitiesByCountry(string countryName);
        Task<List<string>> GetCitiesByCountry(string countryName, string cityName);
    }
}
