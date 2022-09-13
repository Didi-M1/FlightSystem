using BE.Models;
using PLGUI.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for FlightTableUserControl.xaml
    /// </summary>
    public partial class FlightTableUserControl : UserControl
    {
        private TablesViewModle VM;

        public FlightTableUserControl()
        {
            InitializeComponent();
            VM = new TablesViewModle();
            this.DataContext = VM;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FlightInfoPartial flight = (FlightInfoPartial)dataGrid.SelectedItem;
            VM.ChangeSelectedFlight.Execute(flight);
        }
    }
}