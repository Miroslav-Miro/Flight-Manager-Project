namespace FlightManager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FlightManager.Data;
    using FlightManager.Models;
    using FlightManager.Services.Contracts;
    using FlightManager.ViewModels.Flights;
    using FlightManager.ViewModels.Pilots;
    using FlightManager.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.SignalR;
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
                UserId = model.UserId,
                UniqueNumber = model.UniqueNumber,

            };

            await this.context.Flights.AddAsync(flight);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteFlightAsync(string id)
        {
            Flight flight = await this.context.Flights.FindAsync(id);

            this.context.Remove(flight);
            await this.context.SaveChangesAsync();
        }
        public async Task EditFlightByAdminAsync(EditFlightViewModel model)
        {
            Flight flight = await this.context.Flights.FirstOrDefaultAsync(x => x.Id == model.Id);
             flight.StartingLocation = model.StartingLocation;
            flight.Destination = model.Destination;
            flight.TimeTakeOf = model.TimeTakeOf;
            flight.TimeLanding = model.TimeLanding;
            flight.AirplaneType = model.AirplaneType;
            flight.AllSeats = model.AllSeats;
            flight.BusinessClassSeats = model.BusinessClassSeats;
            flight.UserId = model.UserId;
            flight.UniqueNumber = model.UniqueNumber;

            this.context.Update(flight);
            await this.context.SaveChangesAsync();
        }

        public async Task<DetailsFlightViewModel> GetFlightDetails(string id)
        {
            Flight flight = this.context.Flights.Find(id);

            DetailsFlightViewModel model = new DetailsFlightViewModel()
            {
                StartingLocation = flight.StartingLocation,
                Destination = flight.Destination,
                TimeTakeOf = flight.TimeTakeOf,
                TimeLanding = flight.TimeLanding,
                Duration = $"{flight.TimeLanding - flight.TimeTakeOf}",
                AirplaneType = flight.AirplaneType,
                AllSeats = flight.AllSeats,
                BusinessClassSeats = flight.BusinessClassSeats,
                UniqueNumber = flight.UniqueNumber,
            };
            model.Pilot = $"{flight.User.FirstName} {flight.User.LastName}";

            return model;
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
                                Duration = $"{x.TimeLanding - x.TimeTakeOf}",
                                AirplaneType = x.AirplaneType,
                                AllSeats = x.AllSeats,
                                BusinessClassSeats = x.BusinessClassSeats,
                                UniqueNumber = x.UniqueNumber,
                            })
                            .ToListAsync();

            model.ElementsCount = this.context.Flights.Count();

            return model;
        }

        public async Task<EditFlightViewModel> GetFlightToEditAsync(string id)
        {
            Flight flight = await this.context.Flights.FirstOrDefaultAsync(x => x.Id == id);

            return new EditFlightViewModel()
            {
                Id = flight.Id,
                StartingLocation = flight.StartingLocation,
                Destination = flight.Destination,
                TimeTakeOf = flight.TimeTakeOf,
                TimeLanding = flight.TimeLanding,
                AirplaneType = flight.AirplaneType,
                AllSeats = flight.AllSeats,
                BusinessClassSeats = flight.BusinessClassSeats,
                UserId = flight.UserId,
                UniqueNumber = flight.UniqueNumber,
                Pilots = await this.GetPilotsSelectListAsync(),
            };
        }

        public async Task<SelectList> GetPilotsSelectListAsync()
        {

            List<SelectListPilotsViewModel> pilots = await this.context.Users
                .Select(x => new SelectListPilotsViewModel()
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} - {x.LastName}",
                }).ToListAsync();

            return new SelectList(pilots, "Id", "FullName");
        }


    }
}