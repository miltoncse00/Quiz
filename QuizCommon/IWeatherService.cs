using System.Threading.Tasks;

namespace QuizCommon
{
    public interface IWeatherService
    {
        Task<string> GetCitiesByCountry(string countryName);
        Task<CurrentWeather> GetWeather(string country, string city);
    }
}
