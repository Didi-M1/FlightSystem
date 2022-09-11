using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  System.Timers;
using BL;
using BE.Models;
namespace PLGUI.Models
{
    class HolydayModel
    {
        public List<HolydatesInfo> HolydayList { get; set; }        
        IFlightBL Bl;
        public HolydayModel()
        {          
            Bl = new FlightBL();
            HolydayList = Bl.isThereAnyHolday(7, DateTime.Now);           
        }
        public void updateHolyDayList()
        {
            HolydayList = Bl.isThereAnyHolday(7, DateTime.Now);
        }
       
    }
}
