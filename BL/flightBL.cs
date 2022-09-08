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

        public Tuple<WeatherSystem, WeatherSystem> getWatherInfoForSourceAndDes(FlightInfoPartial flight)
        {
            AirportsInfo airports = new AirportsInfo();
            string source = flight.Source;
            string des = flight.Destination;
            AirPort sourceAirport = this.GetAirportInfo(source);
            AirPort desAirport = this.GetAirportInfo(des);
            WeatherSystem sourceWeather = this.getWatherInfo(sourceAirport.Location.lat.ToString(), sourceAirport.Location.lon.ToString());
            WeatherSystem desWeather = this.getWatherInfo(desAirport.Location.lat.ToString(), desAirport.Location.lon.ToString());

            return new Tuple<WeatherSystem, WeatherSystem>(sourceWeather, desWeather);
        }

        public Tuple<string, string> getPathToFlagsForSourceAndDes(FlightInfoPartial flight)
        {
            AirportsInfo airports = new AirportsInfo();
            string source = flight.Source;
            string des = flight.Destination;
            AirPort sourceAirport = this.GetAirportInfo(source);
            AirPort desAirport = this.GetAirportInfo(des);
            string sourceFlag = this.getPathToFlag(sourceAirport.country);
            string desFlag = this.getPathToFlag(desAirport.country);

            return new Tuple<string, string>(sourceFlag, desFlag);
        }

        public string getPathToFlag(string country)
        {
            FlagByCountrey flag = new FlagByCountrey();
            return flag.getImageByName(country);
        }

        public AirPort GetAirportInfo(string airportCode)
        {
            AirportsInfo airports = new AirportsInfo();
            return airports.getAirPortinfo(airportCode);
        }
    }
}
