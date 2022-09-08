using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE.Models;

namespace PLGUI.Commands
{
    class ChangeSelectedFlightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        ViewModel.FlightDataUCVM VM;

        public ChangeSelectedFlightCommand(ViewModel.FlightDataUCVM vm)
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
            var flight=parameter as FlightInfoPartial;
            VM.selectedFlight = flight;
        }
    }
}
