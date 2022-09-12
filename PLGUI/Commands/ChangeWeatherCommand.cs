using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PLGUI.Modles;

namespace PLGUI.Commands
{
    public class ChangeWeatherCommand : ICommand
    {
        private WhetherModel _weatherModel;
        private static ViewModel.MainViewModel _mainVM;
        public ChangeWeatherCommand(ViewModel.MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
        public ChangeWeatherCommand()
        {
            _weatherModel = new WhetherModel();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            
        }

        public event EventHandler CanExecuteChanged;
    }
}
