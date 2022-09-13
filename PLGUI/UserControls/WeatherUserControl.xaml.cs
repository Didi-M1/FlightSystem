using System.Windows.Controls;

namespace PLGUI.UserControls
{
    /// <summary>
    /// Interaction logic for WeatherUserControl.xaml
    /// </summary>
    public partial class WeatherUserControl : UserControl
    {
        private ViewModel.WeatherUCVM vm;

        public WeatherUserControl()
        {
            InitializeComponent();
            vm = ViewModel.WeatherUCVM.Instance;
            this.DataContext = vm;
        }
    }
}