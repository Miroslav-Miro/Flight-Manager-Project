using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FlightManager.ViewModels.Flights
{
    public class EditFlightViewModel
    {
        public string Id { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public DateTime? TimeTakeOf { get; set; }

        public DateTime? TimeLanding { get; set; }

        public string AirplaneType { get; set; }

        public string PilotId { get; set; }

        public SelectList Pilots { get; set; }

        public int AllSeats { get; set; }

        public int BusinessClassSeats { get; set; }
    }
}
