using BE.Models;
using System;
using System.Windows.Input;

namespace PLGUI.Commands
{
    internal class ChangeSelectedFlightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private static ViewModel.MainViewModel VM;
        private ViewModel.FlightDataUCVM flightData;

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