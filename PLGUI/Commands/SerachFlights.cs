using PLGUI.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLGUI.Commands
{
    public class SerachFlights : ICommand
    {
        public event EventHandler CanExecuteChanged;
        PLGUI.ViewModel.DatesUCVM VM;
        FlightModel model = new FlightModel();

        public SerachFlights(PLGUI.ViewModel.DatesUCVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            VM.Flights = new System.Collections.ObjectModel.ObservableCollection<BE.Models.FlightInfoPartial>(model.getSavedFlights());
        }
    }
}
