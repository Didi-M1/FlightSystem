using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BE.Models;
using BL;
using PLGUI.ViewModel;

namespace PLGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BL.IFlightBL bl;
        PLGUI.ViewModel.FlightsUCVM flightsUCVM;
        public MainWindow()
        {

            InitializeComponent();

            flightsUCVM = new ViewModel.FlightsUCVM();
            bl = new FlightBL();
            addLinesAndFlights(flightsUCVM);
            DataContext = flightsUCVM;
        }

        private void addLinesAndFlights(FlightsUCVM flightsUCVM)
        {
            foreach (var item in flightsUCVM.Incomaingflights)
            {
                Location location = new Location(item.Lat, item.Long);
                DrawLines(item, location);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.Background = Brushes.Red;
                pushpin.Content = item.SourceId;
                pushpin.ToolTip = item.FlightCode;
                pushpin.MouseDoubleClick += flightsUCVM.Pushpin_MouseDoubleClick;
                myMap.Children.Add(pushpin);
            }
            foreach (var item in flightsUCVM.Outgoingflights)
            {
                Location location = new Location(item.Lat, item.Long);
                DrawLines(item, location);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.Background = Brushes.Green;
                pushpin.Content = item.FlightCode;
                pushpin.ToolTip = item.FlightCode;
                pushpin.MouseDoubleClick += flightsUCVM.Pushpin_MouseDoubleClick;
                myMap.Children.Add(pushpin);
            }


        }
        private void DrawLines(FlightInfoPartial item, Location location)
        {
            var airPortA = bl.GetAirportInfo(item.Source);
            Location locationA = new Location(airPortA.Location.lat, airPortA.Location.lon);
            var airPortB = bl.GetAirportInfo(item.Destination);
            Location locationB = new Location(airPortB.Location.lat, airPortB.Location.lon);
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Red);
            polyline.StrokeThickness = 1;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection() { locationA, location, locationB };
            myMap.Children.Add(polyline);
        }

 

     
    }
}



