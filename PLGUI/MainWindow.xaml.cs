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
using Microsoft.Maps.MapControl.WPF;

namespace PLGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IFlightBL BL = new FlightBL();
        public MainWindow()
        {
            
            InitializeComponent();
            
            addNewPolyline();

        }
        void addNewPolyline()
        {
            MapPolyline polyline = new MapPolyline();
            polyline.Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
            polyline.StrokeThickness = 5;
            polyline.Opacity = 0.7;
            polyline.StrokeEndLineCap = PenLineCap.Triangle;
            polyline.StrokeDashArray = new DoubleCollection()
            {0.1};
            polyline.Locations = new LocationCollection() {
            new Location(31.27330610835083, 34.77931980666788),
            new Location(48.20471106811736, 16.37565655829858)};

            myMap.Children.Add(polyline);
        }

    }

    
}
