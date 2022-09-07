using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace FlightSystem1
{
    class Program
    {
        static void Main(string[] args)
        {
            TrafficAdapter traffic = new TrafficAdapter();
            var flights = traffic.GetCurrentFlights();
        }
    }
}
