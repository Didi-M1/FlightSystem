using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models;
using BL;

namespace PLGUI.Models
{
    class FlightDataModel
    {
        IFlightBL Bl;
        private FlightInfoPartial SelectedFlight;
        public FlightInfoPartial selectedFlight {
            get
            {             
                return SelectedFlight;
            }
            set
            {
                Bl.addFLightToSaves(value);
                SelectedFlight = value;
            }
            }
        public FlightInfo selectedFlightFullInfo { get; set; }
        public FlightDataModel()
        {
            Bl = new FlightBL();
        }
        public void getFlightInfo()
        {
            selectedFlightFullInfo = Bl.GetFlightFullInfo(SelectedFlight.SourceId);
        }
        public Tuple<string,string> pathToFlags
        {
            get
            {
                return Bl.getPathToFlagsForSourceAndDes(SelectedFlight);
            }
        }
        
    }
}
