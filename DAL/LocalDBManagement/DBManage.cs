using BE.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class DBManage
    {
        public void AddAirPort(AirPort newAitport)
        {
            using (var ctx = new FlightsShowDB())
            {
                ctx.DBAirports.Add(newAitport);
                ctx.SaveChanges();
            }
        }

        public AirPort getAirPort(string airCode)
        {
            using (var ctx = new FlightsShowDB())
            {
                return ctx.DBAirports.Find(airCode);
            }
        }

        public void AddFlight(FlightInfoPartial flight)
        {
            using (var ctx = new FlightsShowDB())
            {
                ctx.DBFligths.Add(flight);
                ctx.SaveChanges();
            }
        }

        public void RemoveFlight(int id)
        {
            using (var ctx = new FlightsShowDB())
            {
                ctx.DBFligths.Remove(ctx.DBFligths.Where(F => F.Id == id).FirstOrDefault());
                ctx.SaveChanges();
            }
        }

        public List<FlightInfoPartial> getAllFlights()
        {
            using (var ctx = new FlightsShowDB())
            {
                return ctx.DBFligths.ToList();
            }
        }

        public FlightInfoPartial GetFlight(int id)
        {
            using (var ctx = new FlightsShowDB())
            {
                var query = from flight in ctx.DBFligths
                            where flight.Id == id
                            select flight;
                return query.FirstOrDefault();
            }
        }
    }
}