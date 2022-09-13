using BE.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PLGUI.ViewModel
{
    internal class MapUCVM : BaseViewModel
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

        public ICommand ChangeSelectedFlight { get; set; }

        public MapUCVM()
        {
            ViewMathod = true;
            FlightsUCVM vm = new FlightsUCVM();
            Incomaingflights = vm.Incomaingflights;
            Outgoingflights = vm.Outgoingflights;
            ChangeSelectedFlight = new Commands.ChangeSelectedFlightCommand();
        }

        private FlightDataUCVM FlightDataUCVM = FlightDataUCVM.Instance;
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }

        public FlightInfoPartial SelectdFlight
        {
            get
            {
                return FlightDataUCVM.selectedFlight;
            }
        }
    }
}