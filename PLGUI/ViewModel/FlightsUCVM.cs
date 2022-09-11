using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BE.Models;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Input;

namespace PLGUI.ViewModel
{
    class FlightsUCVM
    {
        private PLGUI.Modles.FlightModel Model;
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }
        public Map myMap { get; set; }
        public PLGUI.Commands.UpdateFlightsCommand updateCommand;
        public PLGUI.Commands.ChangeViewMathod ClickCommandSwitch { get; set; }


        public bool ViewMathod
        {
            get { return viewMathod; }
            set
            {
                viewMathod = value;
            }
        }
        private bool viewMathod = true;




        public FlightsUCVM()
        {
            Model = new Modles.FlightModel();
            Incomaingflights = new ObservableCollection<FlightInfoPartial>();
            Outgoingflights = new ObservableCollection<FlightInfoPartial>();
            myMap = new Map();
            updateCommand = new Commands.UpdateFlightsCommand(this);
            ClickCommandSwitch = new Commands.ChangeViewMathod(this);
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
        public void Pushpin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            FlightInfoPartial flight = Incomaingflights.FirstOrDefault(x => x.SourceId == pushpin.Content.ToString());
            clearMap();
            
        }
        public void clearMap()
        {
            myMap.Children.Clear();
        }

        //switch from map to data grid using flightTableUserControl 
        public void SwitchView()
        {
            
        }


    }

}
