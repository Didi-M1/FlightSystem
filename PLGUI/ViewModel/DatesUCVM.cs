using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BE.Models;

namespace PLGUI.ViewModel
{
    public class DatesUCVM : BaseViewModel
    {
        private ObservableCollection<FlightInfoPartial> flights { get; set; }
        public ObservableCollection<FlightInfoPartial> Flights
        {
            get { return flights; }
            set
            {
                flights = value;
                OnPropertyChanged("Flights");
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public ICommand SerachFlights { get; set; }
        public DatesUCVM()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SerachFlights = new Commands.SerachFlights(this);
        }
    }
}
