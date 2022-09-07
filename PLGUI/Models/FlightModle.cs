using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using BL;
namespace PLGUI.Modles
{
    internal class FlightModle
    {
        //list of flights
        public List<FlightInfoPartial> flights { get; set; }
        private IFlightBL Bl;
        FlightModle()
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
            return Bl.getAllIncomingFlights();
        }
        
    }
   


        

    }

