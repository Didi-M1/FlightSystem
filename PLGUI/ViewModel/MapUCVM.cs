using BE.Models;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLGUI.ViewModel
{


    class MapUCVM : BaseViewModel
    {
    
        private bool _viewMathod;
        public bool ViewMathod
        {
            get { return _viewMathod; }
            set
            {
                _viewMathod = value;
                OnPropertyChanged("ViewMathod");
            }
        }


        ICommand ChangeSelectedFlight { get; set; }

        public MapUCVM()
        {
            ViewMathod = true;
            FlightsUCVM vm = new FlightsUCVM();
            Incomaingflights = vm.Incomaingflights;
            Outgoingflights = vm.Outgoingflights;
            ChangeSelectedFlight = new Commands.ChangeSelectedFlightCommand();
        }


        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }

        public void Pushpin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            FlightInfoPartial flight = Incomaingflights.FirstOrDefault(x => x.FlightCode == pushpin.Content.ToString());
            if (flight == null)
            {
                flight = Outgoingflights.FirstOrDefault(x => x.FlightCode == pushpin.Content.ToString());
            }

            ChangeSelectedFlight.Execute(flight);
        }

    }
}
