using BE.Models;
using BL;
using System.Collections.Generic;

namespace PLGUI.Modles
{
    internal class FlightModel
    {
        //list of flights
        public List<FlightInfoPartial> flights { get; set; }

        private IFlightBL Bl;

        public FlightModel()
        {
            Bl = new FlightBL();
        }

        public Dictionary<string, List<FlightInfoPartial>> getAllFlights()
        {
            return Bl.getAllFlights();
        }

        public IEnumerable<FlightInfoPartial> getIncomingFlights()
        {
            return Bl.getAllIncomingFlights();
        }

        public IEnumerable<FlightInfoPartial> getFlights()
        {
            return Bl.getAllOutgoingFlights();
        }

        public IEnumerable<FlightInfoPartial> getSavedFlights()
        {
            return Bl.GetAllSaveFlights();
        }
    }
}