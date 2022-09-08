using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  DAL;

namespace FlightSystem1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficAdapter traffic = new TrafficAdapter();
            var flights = traffic.GetCurrentFlights();
            foreach (var flight in flights)
            {
                string airPortName = flight.Value[0].Source;
                var airPort = new AirportsInfo();
                var airPortInfo = airPort.getAirPortinfo(airPortName);
                FlagByCountrey flag = new FlagByCountrey();
                string flagPath = flag.getImageByName(airPortInfo.country);
                Console.WriteLine(flight);
            }
            

        }
    }
}
