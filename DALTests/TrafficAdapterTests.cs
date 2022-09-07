using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;

namespace DAL.Tests
{
    [TestClass()]
    public class TrafficAdapterTests
    {
        [TestMethod()]
        public void GetFlightTest()
        {
            /*
            TrafficAdapter ta = new TrafficAdapter();
            var flights=ta.GetCurrentFlights();          
            ta.GetFlight(flights["Outgoing"][1].FlightCode);*/
            AirportsInfo airports = new AirportsInfo();
            
            var airport=airports.getAirPortinfo("TLV");

            DAL.FlagByCountrey fbc = new FlagByCountrey();
            fbc.getImageByName("Andorra");
            
        }
    }
}