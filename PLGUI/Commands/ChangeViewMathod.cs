using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLGUI.Commands
{
    class ChangeViewMathod : ICommand
    {
        public event EventHandler CanExecuteChanged;
        PLGUI.ViewModel.MainViewModel VM;

        ViewModel.TablesViewModle tableVM = new ViewModel.TablesViewModle();
        ViewModel.MapUCVM mapVM = new ViewModel.MapUCVM();
        ViewModel.DatesUCVM datesVM = new ViewModel.DatesUCVM();


        public ChangeViewMathod(ViewModel.MainViewModel vm)
        {
            VM = vm;
            VM.CurrentUC = mapVM;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Map":
                    VM.CurrentUC = mapVM;
                    break;
                case "List":
                    VM.CurrentUC = tableVM;
                    break;
                case "Dates":
                    VM.CurrentUC = datesVM;
                    break;
                default:
                    break;
            }
        }
    }
}
