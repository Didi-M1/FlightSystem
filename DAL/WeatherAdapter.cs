using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;

namespace DAL
{
    public class WeatherAdapter
    {
        public const string AllURL = @"http://api.openweathermap.org/data/2.5/forecast?id=524901&appid=";
        public const string URLbaseOnLocation = @"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}";
        public const string WeatherUrl = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        public const string APIkey = @"291e223a32f298d26000aab581f08ae0";

        public WeatherSystem GetCurrentWeather(string lat, string lon)
        {
            string url = URLbaseOnLocation.Replace("{lat}", lat).Replace("{lon}", lon).Replace("{API key}", APIkey);
            WeatherSystem Result = new WeatherSystem();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(url);
                Result = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherSystem>(json);
            }
            return Result;
        }



    }
}
