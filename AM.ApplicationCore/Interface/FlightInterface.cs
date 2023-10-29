using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface FlightInterface
    {
        public IList<DateTime> GetFlightDates(string dest);
    }
}
