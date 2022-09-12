using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using BL;
namespace PLGUI.Modles
{
    public class WhetherModel
    {
        //list of whethers
        public List<WeatherSystem> WeatherModle { get; set; }
        private IFlightBL Bl;
        public WhetherModel()
        {
            Bl = new FlightBL();
        }

        

    }
}
