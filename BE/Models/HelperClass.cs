using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
    public class HelperClass
    {
        public HelperClass() { }

        //Helper Function to Convert from Unix Epoch time Human DateTime
        public DateTime GetDateTimeFromEpoch(double EpochTimeStamp)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, 0); //from start epoch time
            start = start.AddSeconds(EpochTimeStamp); //add the seconds to the start DateTime
            return start;
        }
        public DateTime GetDateTimeFromString(string date)
        {
            return DateTime.Parse(date);
        }
    }
}
