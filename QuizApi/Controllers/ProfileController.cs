using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json.Linq;
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

        [Route("cities/{country}")]
        public async Task<HttpResponseMessage> GetCities(string country)
        {

            var citiesByCountryAsync = await _service.GetCitiesByCountry(country);
            var countries = ConvertToAnother(citiesByCountryAsync);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

        private List<string> ConvertToAnother(string obj)
        {
            List<string> items = new List<string>();
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(obj); // suppose that myXmlString contains "<Names>...</Names>"

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

        [Route("weather")]
        [HttpPost]
        public async Task<HttpResponseMessage> GetWeather([FromBody]JObject data)
        {
            var city = data["city"].ToObject<string>();
            var country = data["country"].ToObject<string>();
            CurrentWeather countries = await _service.GetWeather(country, city);
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

    }
}
