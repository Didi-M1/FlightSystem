using PLGUI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PLGUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentUC;
        public BaseViewModel CurrentUC
        {
            get { return _currentUC; }
            set
            {
                _currentUC = value;
                OnPropertyChanged("CurrentUC");
            }
        }
        public ICommand ChangeViewMathod { get; set; }

        private BaseViewModel flightDataUCVM;
        public BaseViewModel choosenFlightUC
        {
            get { return flightDataUCVM; }
            set
            {
                flightDataUCVM = value;
                OnPropertyChanged("choosenFlightUC");
            }
        }

        private BaseViewModel weatherUC;
        public BaseViewModel WeatherUC
        {
            get { return weatherUC; }
            set
            {
                weatherUC = value;
                OnPropertyChanged("WeatherUC");
            }
        }


        public MainViewModel()
        {
            ChangeViewMathod = new Commands.ChangeViewMathod(this);
            new Commands.ChangeSelectedFlightCommand(this);
        }

    }
}
