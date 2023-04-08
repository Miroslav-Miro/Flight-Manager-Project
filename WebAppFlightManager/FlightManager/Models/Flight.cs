namespace FlightManager.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class Flight
    {
        public Flight()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public DateTime? TimeTakeOf { get; set; }

        public DateTime? TimeLanding { get; set; }

        public string AirplaneType { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int UniqueNumber { get; set; }

        public int AllSeats { get; set; }

        public int BusinessClassSeats { get; set; }
    }
}
