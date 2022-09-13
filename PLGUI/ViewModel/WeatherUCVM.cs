using BE.Models;

namespace PLGUI.ViewModel
{
    public class WeatherUCVM : BaseViewModel
    {
        private WeatherSystem _weatherSystem;

        public WeatherSystem WeatherSystem
        {
            get { return _weatherSystem; }
            set
            {
                _weatherSystem = value;
                OnPropertyChanged("WeatherSystem");
            }
        }

        private static WeatherUCVM instance = null;

        public static WeatherUCVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WeatherUCVM();
                }
                return instance;
            }
        }

        private WeatherUCVM()
        {
            WeatherSystem = new WeatherSystem();
        }
    }
}