using System;

namespace FlightManager.ViewModels.Flights
{
    public class DetailsFlightViewModel
    {
        public int UniqueNumber { get; set; }

        public string StartingLocation { get; set; }

        public string Destination { get; set; }

        public DateTime? TimeTakeOf { get; set; }

        public DateTime? TimeLanding { get; set; }

        public string Duration { get; set; }

        public string AirplaneType { get; set; }

        public string UserId { get; set; }

        public string Pilot { get; set; }

        public int AllSeats { get; set; }

        public int BusinessClassSeats { get; set; }
    }
}
