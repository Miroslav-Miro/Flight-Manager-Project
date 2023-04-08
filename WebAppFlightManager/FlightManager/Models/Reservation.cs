﻿namespace FlightManager.Models
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

        public string PIN { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public string Email { get; set; }

        public string FlightId { get; set; }

        public virtual Flight Flights { get; set; }



    }
}