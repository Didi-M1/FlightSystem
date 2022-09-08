using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BE.Models;
using Microsoft.Maps.MapControl.WPF;
namespace PLGUI.ViewModel
{
    class FlightsUCVM
    {
        
        private PLGUI.Modles.FlightModel Model;
        public ObservableCollection<Tuple<Location, FlightInfoPartial>> Incomaingflights { get; set;}
        public ObservableCollection<Tuple<Location, FlightInfoPartial>> Outgoingflights { get; set; }
        
        public PLGUI.Commands.UpdateFlightsCommand updateCommand;
        public FlightsUCVM()
        {
            Model = new Modles.FlightModel();
            Incomaingflights = new ObservableCollection<Tuple<Location, FlightInfoPartial>>();
            Outgoingflights = new ObservableCollection<Tuple<Location, FlightInfoPartial>>();
            updateCommand =new Commands.UpdateFlightsCommand(this);
        }
        public void getAllFlights()
        {
            var dic=Model.getAllFlights();
            if(dic.ContainsKey("Incoming") && dic["Incoming"] !=null)
            {
                for (int i = 0; i < dic["Incoming"].Count; i++)
                {
                    Incomaingflights.Add(new Tuple<Location, FlightInfoPartial>(new Location(dic["Incoming"][i].Lat, dic["Incoming"][i].Long), dic["Incoming"][i]));
                }
            }
            if (dic.ContainsKey("Outgoing") && dic["Outgoing"] != null)
            {
                for (int i = 0; i < dic["Outgoing"].Count; i++)
                {
                    Outgoingflights.Add(new Tuple<Location, FlightInfoPartial>(new Location(dic["Outgoing"][i].Lat, dic["Outgoing"][i].Long), dic["Outgoing"][i]));
                }
            }

        }

    }
}
