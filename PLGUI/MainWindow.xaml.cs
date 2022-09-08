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
        PLGUI.ViewModel.FlightsUCVM flightsUCVM;
        public MainWindow()
        {

            InitializeComponent();

            flightsUCVM = new ViewModel.FlightsUCVM();
            flightsUCVM.getAllFlights();
            this.DataContext = flightsUCVM;
        }


        private void DrawLines(FlightInfoPartial item, Location location)
        {
            /*
            var airPortA = bl.GetAirportInfo(item.Source);
            Location locationA = new Location(airPortA.Location.lat, airPortA.Location.lon);
            var airPortB = bl.GetAirportInfo(item.Destination);
            Location locationB = new Location(airPortB.Location.lat, airPortB.Location.lon);
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection() { locationA, location, locationB };
            myMap.Children.Add(polyline);
            */
        }
    }
}


