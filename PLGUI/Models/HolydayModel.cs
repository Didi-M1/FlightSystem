using BE.Models;
using BL;
using System;
using System.Collections.Generic;

namespace PLGUI.Models
{
    internal class HolydayModel
    {
        public List<HolydatesInfo> HolydayList { get; set; }
        private IFlightBL Bl;

        public HolydayModel()
        {
            Bl = new FlightBL();
            HolydayList = Bl.isThereAnyHolday(7, DateTime.Now);
        }

        public void updateHolyDayList(DateTime date)
        {
            HolydayList = Bl.isThereAnyHolday(7, date);
        }
    }
}