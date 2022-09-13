using PLGUI.Modles;
using System;
using System.Linq;
using System.Windows.Input;

namespace PLGUI.Commands
{
    public class SerachFlights : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private PLGUI.ViewModel.DatesUCVM VM;
        private FlightModel model = new FlightModel();

        public SerachFlights(PLGUI.ViewModel.DatesUCVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;
            var flights = model.getSavedFlights();

            //get only flights that are in the dates range
            var flightsInRange = flights.Where(f => f.DateAndTime >= VM.StartDate && f.DateAndTime <= VM.EndDate);
            VM.Flights = new System.Collections.ObjectModel.ObservableCollection<BE.Models.FlightInfoPartial>(flightsInRange);
        }
    }
}