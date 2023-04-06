namespace FlightManager.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using FlightManager.Data;
    using FlightManager.Models;
    using FlightManager.Services.Contracts;
    using FlightManager.ViewModels.Flights;
    using FlightManager.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class FlightsService : IFlightsService
    {
        private readonly ApplicationDbContext context;

        public FlightsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateFlightAsync(CreateFlightViewModel model)
        {
            User pilot = this.context.Users.FirstOrDefault(x => x.Id == model.UserId);

            Flight flight = new Flight()
            {
                  StartingLocation = model.StartingLocation,
                  Destination = model.Destination,
                  TimeTakeOf = model.TimeTakeOf,
                  TimeLanding = model.TimeLanding,
                  AirplaneType = model.AirplaneType,
                  AllSeats = model.AllSeats,
                  BusinessClassSeats = model.BusinessClassSeats,
                  Pilot = pilot,
            };

            await this.context.Flights.AddAsync(flight);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteRequest(string id)
        {
            Flight flight = await this.context.Flights.FindAsync(id);

            context.Remove(flight);
            await context.SaveChangesAsync();
        }

        public async Task<IndexFlightsViewModel> GetFlightsAsync(IndexFlightsViewModel model)
        {
            model.Flights = await this.context.Flights
                            .Skip((model.Page - 1) * model.ItemsPerPage)
                            .Take(model.ItemsPerPage)
                            .Select(x => new IndexFlightViewModel()
                            {
                                Id = x.Id,
                                StartingLocation = x.StartingLocation,
                                Destination = x.Destination,
                                TimeTakeOf = x.TimeTakeOf,
                                TimeLanding = x.TimeLanding,
                                AirplaneType = x.AirplaneType,
                                AllSeats = x.AllSeats,
                                BusinessClassSeats = x.BusinessClassSeats,
                            })
                            .ToListAsync();

            model.ElementsCount = this.context.Flights.Count();

            return model;
        }



    }
}
