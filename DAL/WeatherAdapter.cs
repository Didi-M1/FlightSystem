using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;

namespace DAL
{
    public class Weather
    {
        public const string AllURL = @"http://api.openweathermap.org/data/2.5/forecast?id=524901&appid=";
        public const string URLbaseOnLocation = @"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API key}";
        public const string WeatherUrl = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";
        public const string APIkey = @"291e223a32f298d26000aab581f08ae0";
        /*
        public Dictionary<string, List<WeatherSystem>> GetCurrentWeather(string lat, string lon)
        {
            Dictionary<string, List<WeatherSystem>> Result = new Dictionary<string, List<WeatherSystem>>();

            using (var webClient = new System.Net.WebClient())
            {
                string currntUrl = AllURL.Replace()
                var json = webClient.DownloadString(AllURL);

                HelperClass Helper = new HelperClass();
                AllFlightData = JObject.Parse(json);

                try
                {
                    foreach (var item in AllFlightData)
                    {
                        var key = item.Key;
                        if (key == "full_count")
                            continue;
                        if (key == "version")
                            continue;
                        if (item.Value[11].ToString() == "TLV")
                            Outgoing.Add(new FlightInfoPartial { Id = -1, Source = item.Value[11].ToString(), Destination = item.Value[12].ToString(), SourceId = key, Long = Convert.ToDouble(item.Value[1]), Lat = Convert.ToDouble(item.Value[2]), DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])), FlightCode = item.Value[13].ToString() });
                        if (item.Value[12].ToString() == "TLV")
                            Incoming.Add(new FlightInfoPartial { Id = -1, Source = item.Value[11].ToString(), Destination = item.Value[12].ToString(), SourceId = key, Long = Convert.ToDouble(item.Value[1]), Lat = Convert.ToDouble(item.Value[2]), DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])), FlightCode = item.Value[13].ToString() });
                    }
                }
                catch (Exception e)
                {
                    Debug.Print(e.Message);
                }

                Result.Add("Incoming", Incoming);
                Result.Add("Outgoing", Outgoing);

                return Result;
            }


            return null;
        }
        */



    }
}
