namespace FlightManager.Models
{
    using System;
    using FlightManager.Models.Enums;

    public class Reservation : Client
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public TicketType TicketType { get; set; }

        public string FlightId { get; set; }

        public virtual Flight Flights { get; set; }



    }
}