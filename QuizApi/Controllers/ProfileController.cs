using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using QuizCommon;
using QuizService;

namespace QuizApi.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController : BaseController
    {
        [Route("current")]
        public HttpResponseMessage GetCurrent()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Name = "Carlos", LastName="Martinez", DateOfBirth= new DateTime(1979, 9, 6) });
        }

        [Route("cities/{country}")]
        public async  Task<HttpResponseMessage> GetCissties(string country)
        {
           var globalWeather = new GlobalWeather();
            List<string> countries = await globalWeather.GetCitiesByCountry(country);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

        [Route("weather/{country}/{city")]
        public async Task<HttpResponseMessage> GetWeather(string country, string city)
        {
            var globalWeather = new GlobalWeather();
            CurrentWeather countries = await globalWeather.GetWeather(country, city);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

    }
}
