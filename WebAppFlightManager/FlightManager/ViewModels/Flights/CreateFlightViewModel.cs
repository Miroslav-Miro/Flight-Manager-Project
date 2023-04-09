namespace FlightManager.ViewModels.Flights
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateFlightViewModel
    {
        [Required]
        public int UniqueNumber { get; set; }

        [Required]
        public string StartingLocation { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime? TimeTakeOf { get; set; }

        [Required]
        public DateTime? TimeLanding { get; set; }

        [Required]
        public string AirplaneType { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public SelectList Pilots { get; set; }

        [Required]
        public int AllSeats { get; set; }

        [Required]
        public int BusinessClassSeats { get; set; }
    }
}
