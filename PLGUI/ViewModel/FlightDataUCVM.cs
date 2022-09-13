using BE.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            getWeather = new Commands.ChangeWeatherCommand();
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
                _selectedFlight = value;
                model.selectedFlight = value;
                OnPropertyChanged("selectedFlight");
                OnPropertyChanged("pathToFlagSorce");
                OnPropertyChanged("pathToFlagDestination");
            }
        }

        public string pathToFlagSorce
        {
            get
            {
                string path = @"../Images/un.png";
                if (selectedFlight != null)
                    path = model.pathToFlags.Item1;
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
                return path;
            }
        }

        private Models.FlightDataModel model;
        public ICommand ChangeCommand { get; set; }
        public ICommand getWeather { get; set; }

        public void switchBtn_Click(object sender, RoutedEventArgs e)
        {
            string content = (sender as Button).Content.ToString();
            Tuple<string, FlightInfoPartial> weather = null;
            if (content == "weather source")
                weather = new Tuple<string, FlightInfoPartial>("source", selectedFlight);
            else
                weather = new Tuple<string, FlightInfoPartial>("destination", selectedFlight);
            getWeather.Execute(weather);
        }
    }
}