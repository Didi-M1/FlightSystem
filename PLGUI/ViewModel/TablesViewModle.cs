using BE.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PLGUI.ViewModel
{
    public class TablesViewModle : BaseViewModel
    {
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }
        public ICommand ChangeSelectedFlight { get; set; }

        public TablesViewModle()
        {
            FlightsUCVM vm = new FlightsUCVM();
            Incomaingflights = vm.Incomaingflights;
            Outgoingflights = vm.Outgoingflights;
            ChangeSelectedFlight = new Commands.ChangeSelectedFlightCommand();
        }
    }
}