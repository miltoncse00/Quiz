using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using QuizService.GlobalWeatherService;

namespace QuizService
{
    public class GlobalWeather
    {
        public Task<List<string>> GetCitiesByCountry(string countryName)
        {
            var globalWeatherSoapClient = new GlobalWeatherSoapClient();
            var citiesByCountryAsync = globalWeatherSoapClient.GetCitiesByCountryAsync(countryName);
            var continuationTask = citiesByCountryAsync.ContinueWith(ConvertToAnother);
            return continuationTask;
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
    }
}
