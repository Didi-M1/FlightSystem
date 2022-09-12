using BE.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLGUI.ViewModel
{
    public class TablesViewModle : BaseViewModel
    {
        public ObservableCollection<FlightInfoPartial> Incomaingflights { get; set; }
        public ObservableCollection<FlightInfoPartial> Outgoingflights { get; set; }


        private bool _viewMathod;
        public bool ViewMathod
        {
            get { return _viewMathod; }
            set
            {
                _viewMathod = value;
                OnPropertyChanged("ViewMathod");
            }
        }

        public TablesViewModle()
        {
            ViewMathod = true;
            FlightsUCVM vm = new FlightsUCVM();
            Incomaingflights = vm.Incomaingflights;
            Outgoingflights = vm.Outgoingflights;
        }
    }
}
