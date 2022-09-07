using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using DAL;


namespace BL
{
    public class FlightBL : IFlightBL
    {
        public Dictionary<string, List<FlightInfoPartial>> getAllFlights()
        {
            return new TrafficAdapter().GetCurrentFlights();
        }

        public FlightInfoPartial getFlightInfo(int flightID)
        {
            DBManage db = new DBManage();
            return db.GetFlight(flightID);
        }

        public WeatherSystem getWatherInfo(string lat, string lon)
        {

            return new WeatherAdapter().GetCurrentWeather(lat, lon);
        }

        public List<HolydatesInfo> isThereAnyHolday(int numberOfDayAhed, DateTime date)
        {
            DateTime end = date.AddDays(numberOfDayAhed);
            var holydays = new HolyDates();
            var holydaysInfo = holydays.getHoldayBetweenDates(date, end);
            return holydaysInfo;
        }

        public void addFLightToSaves(FlightInfoPartial flight)
        {
            DBManage db = new DBManage();
            db.AddFlight(flight);
        }

        public void removeFLightFromSaves(int flight)
        {
            try
            {
                DBManage db = new DBManage();
                db.RemoveFlight(flight);
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                throw; //TODO: add exception handling
            }
        }

        public List<FlightInfoPartial> getAllIncomingFlights()
        {
            return this.getAllFlights()["Incoming"];
        }

        public List<FlightInfoPartial> getAllOutgoingFlights()
        {
            return this.getAllFlights()["Outgoing"];
        }
    }
}
