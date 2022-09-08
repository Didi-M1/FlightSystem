using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Program
    {
        public static void Main(string[] args)
        {
            AirportsInfo airports = new AirportsInfo();
            var airport = airports.getAirPortinfo("AAR");
           
        }
    }
}
