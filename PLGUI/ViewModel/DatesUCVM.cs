using BE.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
        public ICommand ChangeSelectedFlight { get; set; }
        private Models.HolydayModel holydayModel;

        public string holydates
        {
            get
            {
                holydayModel.updateHolyDayList(_endDate);
                if (holydayModel.HolydayList.Count != 0)
                {
                    return holydayModel.HolydayList[0].title;
                }
                return null;
            }
        }

        public DatesUCVM()
        {
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            SerachFlights = new Commands.SerachFlights(this);
            ChangeSelectedFlight = new Commands.ChangeSelectedFlightCommand();
            holydayModel = new Models.HolydayModel();
        }
    }
}