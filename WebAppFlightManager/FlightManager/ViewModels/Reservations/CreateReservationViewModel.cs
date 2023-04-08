using FlightManager.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;
using FlightManager.Models;

namespace FlightManager.ViewModels.Reservations
{
    public class CreateReservationViewModel
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PIN { get; set; }

        public string PhoneNumber { get; set; }

        public string Nationality { get; set; }

        public TicketType TicketType { get; set; }

        public string Email { get; set; }

        public virtual Flight Flights { get; set; }
    }
}