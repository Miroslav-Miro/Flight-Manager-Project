using FlightManager.Data;
using FlightManager.Models;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Flights;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class FlightsService : IFlightsService
    {
        private readonly ApplicationDbContext context;

        public FlightsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateFlightAsync(CreateFlightViewModel model)
        {
            //Pilot pilot = this.context.Users.FirstOrDefault(x => x.UserId == model.PilotId);

            Flight flight = new Flight()
            {
                  StartingLocation = model.StartingLocation,
                  Destination = model.Destination,
                  TimeTakeOf = model.TimeTakeOf,
                  TimeLanding = model.TimeLanding,
                  AirplaneType = model.AirplaneType,
                  AllSeats = model.AllSeats,
                  BusinessClassSeats = model.BusinessClassSeats,
                 // Pilot = pilot,
            };

            await this.context.Flights.AddAsync(flight);
            await this.context.SaveChangesAsync();
        }
    }
}
