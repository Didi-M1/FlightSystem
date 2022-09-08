using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE.Models; 
namespace PLGUI.ViewModel
{
    class FlightDataUCVM : INotifyPropertyChanged
    {
        public FlightInfoPartial selectedFlight
        {
            get
            {
                return model.selectedFlight;
            }
                set
            {
                OnPropertyChanged("selectedFlight");
                value.DateAndTime = DateTime.Now;
                model.selectedFlight = value;                
            }
        }

        public string pathToFlagSorce
        {
            get
            {
                if (selectedFlight == null)
                {
                    return @"../Images/un.png";
                }
                return model.pathToFlags.Item1;
            }
        }
        public string pathToFlagDestination
        {
            get
            {
                if (selectedFlight == null)
                {
                    return @"../Images/un.png";
                }
                return model.pathToFlags.Item2;
            }
        }



        Models.FlightDataModel model;
        public PLGUI.Commands.ChangeSelectedFlightCommand changeCommand { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;
        public FlightDataUCVM()
        {
            model = new Models.FlightDataModel();
            changeCommand = new Commands.ChangeSelectedFlightCommand(this);
        }
        private void OnPropertyChanged(string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
       
    }
}
