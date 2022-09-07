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

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            

        }
    }
}
