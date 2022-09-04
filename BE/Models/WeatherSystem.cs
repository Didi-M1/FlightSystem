using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
    public class WeatherSystem
    {
        public Coord coord { get; set; }
        public List<WeatherSyystem> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class WeatherSyystem
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }


    public class Address
    {
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int numHouse { get; set; }
        public int id { get; set; }
        public bool isActive { get; set; }

    }

    public class Airport
    {
        public string country { get; set; }
        public string city { get; set; }
        public string name { get; set; }
        public int id { get; set; }
        public bool isActive { get; set; }

    }

    public class Flight
    {
        public string id { get; set; }
        public Airport source { get; set; }
        public Airport destination { get; set; }
        public double cost { get; set; }
        public TimeSpan duration { get; set; }
        public bool isBag { get; set; }
        public int countSeats { get; set; }

    }

    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string code { get; set; }
        public string gmail { get; set; }
        public string phone { get; set; }
        public DateTime birthday { get; set; }
        public bool isActive { get; set; }
        public Address address { get; set; }

    }

    public class UserFlight
    {
        public int userId { get; set; }
        public string flightId { get; set; }
        public string numSeat { get; set; }
        public bool isActive { get; set; }
        //public Department
        //public flightStatus
    }




    enum Department
    {
        businessClass,
        touristClass,
        firstClass
    }

    enum flightStatus
    {
        Paid,
        Ordered,
        Observered
    }
}
