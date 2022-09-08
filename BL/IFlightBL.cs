using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Models;
namespace BL
{
    public interface IFlightBL
    {
        void addFLightToSaves(FlightInfoPartial flight);
        FlightInfoPartial getFlightInfo(int flightID);
        void removeFLightFromSaves(int flight);
        Tuple<WeatherSystem, WeatherSystem> getWatherInfoForSourceAndDes(FlightInfoPartial flight);
        Tuple<string, string> getPathToFlagsForSourceAndDes(FlightInfoPartial flight);
        string getPathToFlag(string country);
        AirPort GetAirportInfo(string airportCode);
        WeatherSystem getWatherInfo(string lat, string lon);
        Dictionary<string, List<FlightInfoPartial>> getAllFlights();
        List<FlightInfoPartial> getAllIncomingFlights();
        List<FlightInfoPartial> getAllOutgoingFlights();
        List<HolydatesInfo> isThereAnyHolday(int numberOfDayAhed, DateTime date);
    }
}
