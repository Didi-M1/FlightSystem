using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Models
{
    public class FlightInfoPartial
    {
        public FlightInfoPartial(int id, string sourceId, double @long, double lat, DateTime dateAndTime, string source, string destination, string flightCode)
        {
            Id = id;
            SourceId = sourceId;
            Long = @long;
            Lat = lat;
            DateAndTime = dateAndTime;
            Source = source;
            Destination = destination;
            FlightCode = flightCode;
        }
        public FlightInfoPartial()
        {

        }
        public int Id { get; set; }

        public string SourceId { get; set; }

        public double Long { get; set; }

        public double Lat { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Source { get; set; }

        public string Destination { get; set; }

        public string FlightCode { get; set; }
    }
}
