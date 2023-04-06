using System;

namespace FlightManager.ViewModels.Flights
{
    public class IndexFlightViewModel
    {
        public string Id { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public DateTime? TimeTakeOf { get; set; }

        public DateTime? TimeLanding { get; set; }

        public string Duration { get; set; }

        public string AirplaneType { get; set; }

        public string UserId { get; set; }

        public int AllSeats { get; set; }

        public int BusinessClassSeats { get; set; }
    }
}
