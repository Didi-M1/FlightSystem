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

        static ViewModel.MainViewModel VM;
        ViewModel.FlightDataUCVM flightData;

        public ChangeSelectedFlightCommand(ViewModel.MainViewModel vm)
        {
            VM = vm;
        }
        public ChangeSelectedFlightCommand()
        {
            ;
        }


        public bool CanExecute(object parameter)
        {
            return parameter == null ? false : true;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            if (flightData == null)
                flightData = ViewModel.FlightDataUCVM.Instance;
            if (parameter is FlightInfoPartial)
            {
                var flight = parameter as FlightInfoPartial;
                flightData.selectedFlight = flight;
                VM.choosenFlightUC = flightData;
            }
        }
    }
}
