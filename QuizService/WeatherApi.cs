using System.Net;
using System.Threading.Tasks;
using System.Xml;
using QuizCommon;

namespace QuizService
{
    public class WeatherApi
    {
        public WeatherApi()
        {
          
        }

        public string GetTemp(XmlDocument document)
        {
            XmlNode temp_node = document.SelectSingleNode("//temperature");
            XmlAttribute temp_value = temp_node.Attributes["value"];
            string temp_string = temp_value.Value;
            return temp_string;
        }

        private const string APIKEY = "b1b15e88fa797225412429c1c50c122a1";
        private string CurrentURL;

        private void SetCurrentURL(string location)
        {
            CurrentURL = "http://samples.openweathermap.org/data/2.5/weather?q="
                         + location + "&mode=xml&APPID=" + APIKEY;
        }

        protected virtual Task<string> GetXML(string city)
        {
            SetCurrentURL(city);
            using (WebClient client = new WebClient())
            {
                Task<string> xmlContent = client.DownloadStringTaskAsync(CurrentURL);
                return xmlContent;
            }
        }

        public async Task<CurrentWeather> GetWeather(string city)
        {
            
            var  weatherString = await  GetXML(city);
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