using BE.Models;
using System;
using System.Collections.Generic;

namespace BL
{
    public interface IFlightBL
    {
        void addFLightToSaves(FlightInfoPartial flight);

        FlightInfoPartial getFlightInfo(int flightID);

        IEnumerable<FlightInfoPartial> GetAllSaveFlights();

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

        FlightInfo GetFlightFullInfo(string sourceID);
    }
}