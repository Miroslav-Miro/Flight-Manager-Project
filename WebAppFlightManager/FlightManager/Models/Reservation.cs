namespace FlightManager.Models
{
    using System;
    using FlightManager.Models.Enums;

    public class Reservation
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int PIN { get; set; }

        public int PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public string Email { get; set; }

        public string FlightId { get; set; }

        public virtual Flight Flight { get; set; }



    }
}