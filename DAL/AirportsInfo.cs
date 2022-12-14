using BE.Models;
using Newtonsoft.Json.Linq;
using System;

namespace DAL
{
    public class AirportsInfo
    {
        private string url = "https://airlabs.co/api/v9/airports?";
        private string apiKey = "4e775779-9df6-4d2c-a119-1a73b319cae0";

        private AirPort getAirPortinfoFromLocal(string iata_code)
        {
            try
            {
                DBManage db = new DBManage();
                return db.getAirPort(iata_code);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private AirPort GetAirportFromWeb(string iata_code)
        {
            AirPort result = new AirPort();
            result.id = iata_code;
            string Url = url + "iata_code=" + iata_code + "&api_key=" + apiKey;
            JObject AirPortsInfo = null;
            try
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(Url);
                    AirPortsInfo = JObject.Parse(json);
                    var item = AirPortsInfo["response"][0];
                    result.name = (string)item["name"];
                    result.Location = new Coord();
                    result.Location.lat = (double)item["lat"];
                    result.Location.lon = (double)item["lng"];
                    result.country = (string)item["country_code"];
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        public AirPort getAirPortinfo(string iata_code)
        {
            AirPort result = getAirPortinfoFromLocal(iata_code);
            if (result != null) return result;
            result = GetAirportFromWeb(iata_code);
            DBManage dB = new DBManage();
            dB.AddAirPort(result);
            return result;
        }
    }
}