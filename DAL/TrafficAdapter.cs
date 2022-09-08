using BE.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TrafficAdapter
    {
        public const string AllURL = @"https://data-cloud.flightradar24.com/zones/fcgi/feed.js?faa=1&satellite=1&mlat=1&flarm=1&adsb=1&gnd=1&air=1&vehicles=1&estimated=1&maxage=14400&gliders=1&stats=1";
        public const string FlightURL = @"https://data-live.flightradar24.com/clickhandler/?version=1.5&flight=";

        public Dictionary<string, List<FlightInfoPartial>> GetCurrentFlights()
        {
            Dictionary<string, List<FlightInfoPartial>> Result = new Dictionary<string, List<FlightInfoPartial>>();

            JObject AllFlightData = null;

            List<FlightInfoPartial> Incoming = new List<FlightInfoPartial>();
            List<FlightInfoPartial> Outgoing = new List<FlightInfoPartial>();


            //asinc!!!!!!!!!!!

            using (var webClient = new System.Net.WebClient())
            {
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
                            Outgoing.Add(new FlightInfoPartial { Id = -1, Source = item.Value[11].ToString(), Destination = item.Value[12].ToString(), SourceId = key, Long = Convert.ToDouble(item.Value[2]), Lat = Convert.ToDouble(item.Value[1]), DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])), FlightCode = item.Value[13].ToString() });
                        if (item.Value[12].ToString() == "TLV")
                            Incoming.Add(new FlightInfoPartial { Id = -1, Source = item.Value[11].ToString(), Destination = item.Value[12].ToString(), SourceId = key, Long = Convert.ToDouble(item.Value[2]), Lat = Convert.ToDouble(item.Value[1]), DateAndTime = Helper.GetDateTimeFromEpoch(Convert.ToDouble(item.Value[10])), FlightCode = item.Value[13].ToString() });
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
        }
        public FlightInfo GetFlight(string sourceID)
        {
            FlightInfo result = new FlightInfo();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(FlightURL + sourceID);
                result = JsonConvert.DeserializeObject<FlightInfo>(json);             
            }
            return result;
        }
    }
}
