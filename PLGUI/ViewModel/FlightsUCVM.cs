using BE.Models;
using System.Collections.ObjectModel;

namespace PLGUI.ViewModel
{
    internal class FlightsUCVM
    {
        private PLGUI.Modles.FlightModel Model;
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }
        public PLGUI.Commands.UpdateFlightsCommand updateCommand;
        public PLGUI.Commands.ChangeViewMathod ClickCommandSwitch { get; set; }

        public FlightsUCVM()
        {
            Model = new Modles.FlightModel();
            Incomaingflights = new ObservableCollection<FlightInfoPartial>();
            Outgoingflights = new ObservableCollection<FlightInfoPartial>();
            updateCommand = new Commands.UpdateFlightsCommand(this);
            this.getAllFlights();
        }

        public void getAllFlights()
        {
            var dic = Model.getAllFlights();
            if (dic.ContainsKey("Incoming") && dic["Incoming"] != null)
            {
                for (int i = 0; i < dic["Incoming"].Count; i++)
                {
                    Incomaingflights.Add(dic["Incoming"][i]);
                }
            }
            if (dic.ContainsKey("Outgoing") && dic["Outgoing"] != null)
            {
                Outgoingflights = new ObservableCollection<FlightInfoPartial>(dic["Outgoing"]);
            }
        }
    }
}