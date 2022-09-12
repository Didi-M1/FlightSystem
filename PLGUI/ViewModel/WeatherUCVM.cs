using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public WeatherUCVM()
        {

        }
    }
}
