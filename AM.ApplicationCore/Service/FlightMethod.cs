using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class FlightMethod : FlightInterface
    {
        public IList<Flight> Flights = new List<Flight>();
        /*  public IList<DateTime> GetFlightDates(string destination)
          {
              IList<DateTime> dates = new List<DateTime>(); ;
              foreach (var flight in Flights)
              {
                  if (flight.Destination == destination)
                      dates.Add(flight.FlightDate);
              }
              return dates;
          }*/
        public IList<DateTime> GetFlightDates(string destination)
        {
            var dates = from a in Flights
                        where (a.Destination == destination)
                        select (a.FlightDate)
                        ;

            return dates.ToList();
        }

        public void ShowFlightDetails(Plane plane)
        {
            bool foundFlight = false;
            var query = from a in plane.Flights
                        select new { a.FlightDate, a.Destination };

            foreach (var flightDate in query)
            {
                Console.WriteLine($"Date: {flightDate.FlightDate}, Destination: {flightDate.Destination}");

                foundFlight = true;
            }

            if (!foundFlight)
            {
                Console.WriteLine("pas de flights");
            }
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var numberOfFlights = from a in Flights
                                  where (a.FlightDate >= startDate && a.FlightDate <= startDate.AddDays(7))
                                  select a;
            return numberOfFlights.Count();
        }


        public double DurationAverage(string destination)
        {
            /*var moyenne=from a in Flights
                        where(a.Destination == destination)
                        select a.EstimatedDuration;
            return moyenne.Average();*/
            return Flights.Where(flight => flight.Destination == destination).Average(flight => flight.EstimatedDuration);
        }
        public IOrderedEnumerable<Flight> OrderedDurationFlights()
        {
            return Flights.OrderByDescending(flight => flight.EstimatedDuration);
        }
        public List<Passenger> SeniorTravellers(Flight flight)
        {
            var travellers = (from a in flight.Passengers
                          where (a.PassengerType1() == "i am traveller")
                          orderby a.BirthDate ascending
                          select a).Take(3).ToList();
             return travellers;
            //return flight.Passengers.Where(passenger => passenger.PassengerType1() == "i am traveller").OrderBy(passenger => passenger.BirthDate).Take(3).ToList();
        }



    }
}
