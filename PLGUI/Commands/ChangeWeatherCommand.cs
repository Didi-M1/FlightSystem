using BE.Models;
using PLGUI.Modles;
using System;
using System.Windows.Input;

namespace PLGUI.Commands
{
    public class ChangeWeatherCommand : ICommand
    {
        private WhetherModel _weatherModel;
        private static ViewModel.MainViewModel _mainVM;
        private ViewModel.WeatherUCVM _weatherUCVM;

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
            if (parameter is Tuple<string, FlightInfoPartial>)
            {
                Tuple<string, FlightInfoPartial> tuple = (Tuple<string, FlightInfoPartial>)parameter;
                var weatherInfo = _weatherModel.GetWeather(tuple.Item2);
                if (_weatherUCVM == null)
                    _weatherUCVM = ViewModel.WeatherUCVM.Instance;
                if (tuple.Item1 == "source")
                    _weatherUCVM.WeatherSystem = weatherInfo.Item1;
                else
                    _weatherUCVM.WeatherSystem = weatherInfo.Item2;
                _mainVM.WeatherUC = _weatherUCVM;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}