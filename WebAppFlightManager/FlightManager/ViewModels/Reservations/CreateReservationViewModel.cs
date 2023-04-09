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

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PIN { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public TicketType TicketType { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FlightId { get; set; }

        [Required]
        public SelectList Flights { get; set; }
    }
}