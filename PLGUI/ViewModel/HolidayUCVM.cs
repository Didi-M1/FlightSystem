using BE.Models;
using System.Collections.ObjectModel;
using System.Timers;

namespace PLGUI.ViewModel
{
    internal class HolidayUCVM
    {
        private PLGUI.Models.HolydayModel HolydayModel;
        public ObservableCollection<HolydatesInfo> holydates;
        private Timer timer;

        public HolidayUCVM()
        {
            HolydayModel = new Models.HolydayModel();
            holydates = new ObservableCollection<HolydatesInfo>(HolydayModel.HolydayList);
            timer = new Timer(3600000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //  HolydayModel.updateHolyDayList();
            holydates = new ObservableCollection<HolydatesInfo>(HolydayModel.HolydayList);
        }

        public bool checkforHolyday()
        {
            if (holydates.Count == 0) return false;
            return true;
        }
    }
}