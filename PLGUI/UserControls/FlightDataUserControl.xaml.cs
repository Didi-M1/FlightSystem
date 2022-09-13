using System.Windows;
using System.Windows.Controls;

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for FlightDataUserControl.xaml
    /// </summary>
    public partial class FlightDataUserControl : UserControl
    {
        private PLGUI.ViewModel.FlightDataUCVM vm;

        public FlightDataUserControl()
        {
            InitializeComponent();
            vm = PLGUI.ViewModel.FlightDataUCVM.Instance;
            this.DataContext = vm;
        }

        private void switchBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.switchBtn_Click(sender, e);
        }
    }
}