using BE.Models;
using Microsoft.Maps.MapControl.WPF;
using PLGUI.Models;
using PLGUI.ViewModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for MapUserControl.xaml
    /// </summary>
    public partial class MapUserControl : UserControl
    {
        private AirportModel airportModel;
        private MapUCVM mapUCVM;

        public MapUserControl()
        {
            InitializeComponent();
            airportModel = new AirportModel();
            mapUCVM = new MapUCVM();
            addLinesAndFlights();
            DataContext = mapUCVM;
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
                pushpin.MouseDoubleClick += Pushpin_MouseDoubleClick;
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
                pushpin.MouseDoubleClick += Pushpin_MouseDoubleClick;
                this.myMap.Children.Add(pushpin);
            }
        }

        private void Pushpin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Pushpin pushpin = sender as Pushpin;
            FlightInfoPartial flight = mapUCVM.Incomaingflights.FirstOrDefault(x => x.SourceId == pushpin.Content.ToString());
            if (flight == null)
            {
                flight = mapUCVM.Outgoingflights.FirstOrDefault(x => x.FlightCode == pushpin.Content.ToString());
            }
            mapUCVM.ChangeSelectedFlight.Execute(flight);
            clearMap();
            addLinesAndFlights();
        }

        private void clearMap()
        {
            myMap.Children.Clear();
        }

        private void DrawLines(FlightInfoPartial item, Location location)
        {
            var airPortA = airportModel.getAirport(item.Source);
            Location locationA = new Location(airPortA.Location.lat, airPortA.Location.lon);
            var airPortB = airportModel.getAirport(item.Destination);
            Location locationB = new Location(airPortB.Location.lat, airPortB.Location.lon);
            MapPolyline polyline = new MapPolyline();
            if (item == mapUCVM.SelectdFlight)
            {
                polyline.Stroke = new SolidColorBrush(Colors.Blue);
                polyline.StrokeThickness = 1.5;
                polyline.Opacity = 0.8;
            }
            else
            {
                polyline.Stroke = new SolidColorBrush(Colors.Red);
                polyline.StrokeThickness = 1;
                polyline.Opacity = 0.7;
            }
            polyline.Locations = new LocationCollection() { locationA, location, locationB };
            this.myMap.Children.Add(polyline);
        }
    }
}