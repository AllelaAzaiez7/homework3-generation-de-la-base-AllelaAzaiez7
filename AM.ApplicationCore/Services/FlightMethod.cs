using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethod : IFlightMethod
    {
        public IList<Flight> flights = new List<Flight>();
        public List<DateTime> dates = new List<DateTime>();

        public  IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var query = from f in flights
                        group f by f.Destination;
            foreach(var f in query)
            {
                Console.WriteLine("La destination" + f.Key);
                foreach (var p in f )
                {
                    Console.WriteLine("FLight Date " + p.FlightDate);

                } 
            }
            return query;

        }

        public double DurationAverage(string destination)
        {
            //LINQ 

            //var query = from a in flights
            //            where a.Destination == destination
            //          select a.EstimateDuration;

            //return query.Average();

            //LAMBDA 

            return flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //LINQ

            //var query = from f in flights
            //            orderby f.EstimateDuration descending
            //            select f;
            //return query;
            //

            return flights.OrderByDescending(f => f.EstimatedDuration).Select(f => f);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            // LINQ 

            //var query = from a in flights

            //            where DateTime.Compare(a.FlightDate, startDate) > 0
            //            && (a.FlightDate - startDate).TotalDays < 7
            //            select a;
            //return query.Count();

            //LAMBDA 

            return flights.Count(f => ((f.FlightDate - startDate).TotalDays < 7) && (DateTime.Compare(f.FlightDate, startDate) > 0));
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //var query = from p in flight.Passengers.OfType<Traveller>()
            //            orderby p.BirthDate
            //            select p;
            //return query.Take(3);
            //Lambda 
            return flight.Passengers.OfType<Traveller>().OrderBy(p=> p.BirthDate).Select(p=> p);
        }

        public void ShowFlightsDate(Plane plane)
        {
            var query = from a in flights
                        where a.Plane == plane
                        select new { a.FlightDate, a.Destination};
            foreach (var a in query)
            {
                Console.WriteLine("Destination " + a.Destination + " Flight Date : " + a.FlightDate);
            }
        }

      

        IList<DateTime> IFlightMethod.GetFLightDates(string destination) {  
            
            foreach (Flight f in flights)
            { 
                if ( destination== f.Destination)
                {
                    dates.Add(f.FlightDate);
                } 
            }
            return dates;


        }
       
    }
   










}
