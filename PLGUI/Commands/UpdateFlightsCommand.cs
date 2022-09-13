using System;
using System.Windows.Input;

namespace PLGUI.Commands
{
    internal class UpdateFlightsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private PLGUI.ViewModel.FlightsUCVM VM;

        public UpdateFlightsCommand(PLGUI.ViewModel.FlightsUCVM vm)
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
            VM.getAllFlights();
        }
    }
}