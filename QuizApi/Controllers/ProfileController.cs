using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using QuizCommon;
using QuizService;

namespace QuizApi.Controllers
{
    [RoutePrefix("api/profile")]
    public class ProfileController : BaseController
    {
        private readonly IWeatherService _service;

        public ProfileController(IWeatherService service)
        {
            _service = service;
        }
        [Route("current")]
        public HttpResponseMessage GetCurrent()
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { Name = "Carlos", LastName="Martinez", DateOfBirth= new DateTime(1979, 9, 6) });
        }

        [Route("cities/{country}")]
        public async  Task<HttpResponseMessage> GetCities(string country)
        {
          
           var citiesByCountryAsync = _service.GetCitiesByCountry(country);
            var countries = await citiesByCountryAsync.ContinueWith(ConvertToAnother);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

        private List<string> ConvertToAnother(Task<string> obj)
        {
            List<string> items = new List<string>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(obj.Result); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("/NewDataSet/Table");
            foreach (XmlNode xn in xnList)
            {
                var xmlElement = xn["City"];
                if (xmlElement != null)
                {
                    string city = xmlElement.InnerText;
                    items.Add(city);
                }
            }
            return items;
        }

        [Route("weather/{country}/{city}")]

        public async Task<HttpResponseMessage> GetWeather(string country, string city)
        {
        CurrentWeather countries = await _service.GetWeather(country, city);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

    }
}
