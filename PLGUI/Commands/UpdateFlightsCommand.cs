using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace PLGUI.Commands
{
    class UpdateFlightsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        PLGUI.ViewModel.FlightsUCVM VM;

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
