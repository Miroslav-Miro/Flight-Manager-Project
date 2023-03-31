using System;
using System.Collections.Generic;

namespace FlightManager.Models
{
    public class Pilot
    {

        public Pilot()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    }
}
