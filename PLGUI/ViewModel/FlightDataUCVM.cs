using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE.Models; 
namespace PLGUI.ViewModel
{
    public class FlightDataUCVM : BaseViewModel
    {
        
        private static FlightDataUCVM instance = null;
        public static FlightDataUCVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FlightDataUCVM();
                }
                return instance;
            }
        }
        private FlightDataUCVM()
        {
            model = new Models.FlightDataModel();
            ChangeCommand = new Commands.ChangeSelectedFlightCommand();
        }


        private FlightInfoPartial _selectedFlight;
        public FlightInfoPartial selectedFlight
        {
            get
            {
                return _selectedFlight;
            }
                set
            {
                if (value == null)
                    return;
                OnPropertyChanged("selectedFlight");
                value.DateAndTime = DateTime.Now;
                _selectedFlight = value;
                model.selectedFlight = value;
            }
        }

        public string pathToFlagSorce
        {
            get
            {
                string path = @"../Images/un.png";
                if (selectedFlight != null)
                    path = model.pathToFlags.Item1;
                path = path.Substring(3);
                return path;
            }
        }
        public string pathToFlagDestination
        {
            get
            {
                string path = @"../Images/un.png";
                if (selectedFlight != null)
                    path = model.pathToFlags.Item2;
                path = path.Substring(3);
                return path;
            }
        }


        Models.FlightDataModel model;
        public ICommand ChangeCommand { get; set;}



       
    }
}
