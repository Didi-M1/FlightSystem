using BE.Models;
using BL;
using System;
using System.Collections.Generic;

namespace PLGUI.Modles
{
    public class WhetherModel
    {
        public List<WeatherSystem> WeatherModle { get; set; }
        private IFlightBL Bl;

        public WhetherModel()
        {
            Bl = new FlightBL();
        }

        public Tuple<WeatherSystem, WeatherSystem> GetWeather(FlightInfoPartial flight)
        {
            return Bl.getWatherInfoForSourceAndDes(flight);
        }
    }
}