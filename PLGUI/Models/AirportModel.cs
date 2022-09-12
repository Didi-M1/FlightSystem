using BE.Models;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLGUI.Models
{
    public class AirportModel
    {
        IFlightBL Bl;

        public AirportModel()
        {
            Bl = new FlightBL();
        }
        public AirPort getAirport(string airPortCode)
        {
            return Bl.GetAirportInfo(airPortCode);
        }
        
    }
}
