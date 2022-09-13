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
        private PLGUI.ViewModel.MainViewModel VM;

        public MainWindow()
        {
            InitializeComponent();
            VM = new MainViewModel();
            this.DataContext = VM;
        }
    }
}