using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BE.Models;
namespace PLGUI.ViewModel
{
    class FlightsUCVM
    {
        private PLGUI.Modles.FlightModel Model;
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set;}
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }
        
        public PLGUI.Commands.UpdateFlightsCommand updateCommand;
        public FlightsUCVM()
        {
            Model = new Modles.FlightModel();
            Incomaingflights = new ObservableCollection<FlightInfoPartial>();
            updateCommand=new Commands.UpdateFlightsCommand(this);
        }
        public void getAllFlights()
        {
            var dic=Model.getAllFlights();
            if(dic.ContainsKey("Incoming") && dic["Incoming"] !=null)
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
