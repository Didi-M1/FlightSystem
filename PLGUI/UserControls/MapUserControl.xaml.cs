using BE.Models;
using Microsoft.Maps.MapControl.WPF;
using PLGUI.Models;
using PLGUI.ViewModel;
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

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        AirportModel airportModel;
        MapUCVM mapUCVM;
        public MapUserControl()
        {
            InitializeComponent();
            airportModel = new AirportModel();
            mapUCVM = new MapUCVM();
            addLinesAndFlights();
            
        }

        private void addLinesAndFlights()
        {
            foreach (var item in mapUCVM.Incomaingflights)
            {
                Location location = new Location(item.Lat, item.Long);
                DrawLines(item, location);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.Background = Brushes.Red;
                pushpin.Content = item.SourceId;
                pushpin.ToolTip = item.FlightCode;
                pushpin.MouseDoubleClick += mapUCVM.Pushpin_MouseDoubleClick;
               this.myMap.Children.Add(pushpin);
            }
            foreach (var item in mapUCVM.Outgoingflights)
            {
                Location location = new Location(item.Lat, item.Long);
                DrawLines(item, location);
                Pushpin pushpin = new Pushpin();
                pushpin.Location = location;
                pushpin.Background = Brushes.Green;
                pushpin.Content = item.FlightCode;
                pushpin.ToolTip = item.FlightCode;
                pushpin.MouseDoubleClick += mapUCVM.Pushpin_MouseDoubleClick;
                this.myMap.Children.Add(pushpin);
            }


        }


        private void DrawLines(FlightInfoPartial item, Location location)
        {

            var airPortA = airportModel.getAirport(item.Source);
            Location locationA = new Location(airPortA.Location.lat, airPortA.Location.lon);
            var airPortB = airportModel.getAirport(item.Destination);
            Location locationB = new Location(airPortB.Location.lat, airPortB.Location.lon);
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new SolidColorBrush(Colors.Red);
            polyline.StrokeThickness = 1;
            polyline.Opacity = 0.7;
            polyline.Locations = new LocationCollection() { locationA, location, locationB };
            this.myMap.Children.Add(polyline);

        }


    }


}
