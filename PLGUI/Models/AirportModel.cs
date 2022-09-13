using BE.Models;
using BL;

namespace PLGUI.Models
{
    public class AirportModel
    {
        private IFlightBL Bl;

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