namespace FlightManager.ViewModels.Flights
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;

    public class CreateFlightViewModel
    {
        public int UniqueNumber { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public DateTime? TimeTakeOf { get; set; }

        public DateTime? TimeLanding { get; set; }

        public string AirplaneType { get; set; }

        public string UserId { get; set; }

        public SelectList Pilots { get; set; }

        public int AllSeats { get; set; }

        public int BusinessClassSeats { get; set; }
    }
}
