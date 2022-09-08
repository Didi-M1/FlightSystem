using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using BE.Models;


namespace DAL
{
    public class AirportsInfo
    {
        string url = "https://airlabs.co/api/v9/airports?";
        string apiKey = "4e775779-9df6-4d2c-a119-1a73b319cae0";
        private Airport getAirPortinfoFromLocal(string iata_code)
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
        private Airport GetAirportFromWeb(string iata_code)
        {
            Airport result = new Airport();
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
        public Airport getAirPortinfo(string iata_code)
        {
            Airport result = getAirPortinfoFromLocal(iata_code);
            if (result != null) return result;
            result= GetAirportFromWeb(iata_code);
            DBManage dB = new DBManage();
        //    dB.AddAirPort(result);
            return result;
        }
    }
}
