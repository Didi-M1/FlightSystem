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
using BE.Models;

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for DatesSelection.xaml
    /// </summary>
    public partial class DatesSelection : UserControl
    {
        private DatesUCVM vm;

        public DatesSelection()
        {
            InitializeComponent();
            vm = new DatesUCVM();
            this.DataContext = vm;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FlightInfoPartial flight = (FlightInfoPartial)dataGrid.SelectedItem;
            vm.ChangeSelectedFlight.Execute(flight);
        }

        private void showMessageBox(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello World");
        }

        private void serachBtn_Click(object sender, RoutedEventArgs e)
        {
            if (vm.holydates != null)
            {
                MessageBox.Show("there is a holydate in the next 7 days after the selected end date:" + vm.holydates);
            }
        }
    }
}