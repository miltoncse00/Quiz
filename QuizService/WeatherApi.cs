using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using QuizCommon;

namespace QuizService
{
    public class WeatherApi
    {
        public string GetTemp(XmlDocument document)
        {
            XmlNode tempNode = document.SelectSingleNode("//temperature");
            Debug.Assert(tempNode != null, "tempNode != null");
            Debug.Assert(tempNode.Attributes != null, "tempNode.Attributes != null");
            XmlAttribute tempValue = tempNode.Attributes["value"];
            var tempString = tempValue.Value;
            return tempString;
        }

        private const string Apikey = "b1b15e88fa797225412429c1c50c122a1";
        private string _currentUrl;

        private void SetCurrentUrl(string location)
        {
            _currentUrl = "http://samples.openweathermap.org/data/2.5/weather?q="
                         + location + "&mode=xml&APPID=" + Apikey;
        }

        protected virtual Task<string> GetXml(string city)
        {
            SetCurrentUrl(city);
            using (WebClient client = new WebClient())
            {
                Task<string> xmlContent = client.DownloadStringTaskAsync(_currentUrl);
                return xmlContent;
            }
        }

        public async Task<CurrentWeather> GetWeather(string city)
        {
            
            var  weatherString = await  GetXml(city);
            if(weatherString.Contains("error"))
                return new CurrentWeather();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(weatherString);
            var currentWeather = new CurrentWeather();
            currentWeather.Temparature = GetTemp(xmlDocument);
            return currentWeather;
        }
    }
}