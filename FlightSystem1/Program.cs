using DAL;
using System;

namespace FlightSystem1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TrafficAdapter traffic = new TrafficAdapter();
            var flights = traffic.GetCurrentFlights();
            foreach (var flight in flights)
            {
                string airPortName = flight.Value[0].Source;
                var airPort = new AirportsInfo();
                var airPortInfo = airPort.getAirPortinfo(airPortName);
                var weather = new WeatherAdapter();
                var weatherInfo = weather.GetCurrentWeather(airPortInfo.Location.lat.ToString(), airPortInfo.Location.lon.ToString());
                Console.WriteLine(weatherInfo);
                Console.WriteLine(flight);
            }
        }
    }
}