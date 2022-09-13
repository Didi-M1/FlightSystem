using BE.Models;
using BL;
using System;

namespace PLGUI.Models
{
    internal class FlightDataModel
    {
        private IFlightBL Bl;
        private FlightInfoPartial SelectedFlight;

        public FlightInfoPartial selectedFlight
        {
            get
            {
                return SelectedFlight;
            }
            set
            {
                if (value.Id == -1)
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

        public Tuple<string, string> pathToFlags
        {
            get
            {
                return Bl.getPathToFlagsForSourceAndDes(SelectedFlight);
            }
        }
    }
}