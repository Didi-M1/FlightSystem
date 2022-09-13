using System;
using System.Windows.Input;

namespace PLGUI.Commands
{
    internal class ChangeViewMathod : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private PLGUI.ViewModel.MainViewModel VM;

        private ViewModel.TablesViewModle tableVM = new ViewModel.TablesViewModle();
        private ViewModel.MapUCVM mapVM = new ViewModel.MapUCVM();
        private ViewModel.DatesUCVM datesVM = new ViewModel.DatesUCVM();

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