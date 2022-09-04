using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BE.Models;
namespace BL
{
    public interface flightBL
    {
        FlightInfo addFLightToSaves(int flightID);
        void getFlightInfo(int flightID); //TODO: chagne from void 
        void removeFLightFromSaves(int flight);
        void getWatherInfo(int lat, int lon); //TODO: change from void
        void getAllFlights(); //TODO: 
        void changeDate(DateTime dateFrom, DateTime dateTo);
        void isThereAnyHolday(int numberOfDayAhed, DateTime date);
    }
}
