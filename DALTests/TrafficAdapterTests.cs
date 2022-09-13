using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DAL.Tests
{
    [TestClass()]
    public class TrafficAdapterTests
    {
        [TestMethod()]
        public void GetFlightTest()
        {
            TrafficAdapter ta = new TrafficAdapter();
            var flights = ta.GetCurrentFlights();
            ta.GetFlight(flights["Outgoing"][1].SourceId);
            /*AirportsInfo airports = new AirportsInfo();

            var airport=airports.getAirPortinfo("TLV");

            DAL.FlagByCountrey fbc = new FlagByCountrey();
            fbc.getImageByName("Andorra");*/
        }
    }
}