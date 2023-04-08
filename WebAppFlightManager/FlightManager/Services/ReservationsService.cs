using FlightManager.Data;
using FlightManager.Models;
using FlightManager.Services.Contracts;
using FlightManager.ViewModels.Flights;
using FlightManager.ViewModels.Reservations;
using FlightManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services
{
    public class ReservationsService : IReservationsService
    {
        private readonly ApplicationDbContext context;

        public ReservationsService(ApplicationDbContext context)
        {
            this.context = context;
        }



        public async Task CreateReservationAsync(CreateReservationViewModel model)
        {


            Reservation reservation = new Reservation()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PIN = model.PIN,
                PhoneNumber = model.PhoneNumber,
                Nationality = model.Nationality,
                TicketType = model.TicketType,
                Email = model.Email,
                FlightId = model.FlightId,

            };

            await this.context.Reservations.AddAsync(reservation);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(string id)
        {
            Reservation reservation = await this.context.Reservations.FindAsync(id);

            this.context.Remove(reservation);
            await this.context.SaveChangesAsync();
        }

        public Task<DetailsReservationViewModel> GetReservationDetails(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IndexReservationsViewModel> GetReservationsAsync(IndexReservationsViewModel model)
        {
            model.Reservations = await this.context.Reservations
                            .Skip((model.Page - 1) * model.ItemsPerPage)
                            .Take(model.ItemsPerPage)
                            .Select(x => new IndexReservationViewModel()
                            {
                                Id = x.Id,
                                FirstName = x.FirstName,
                                MiddleName= x.MiddleName,
                                LastName= x.LastName,
                                PIN= x.PIN,
                                PhoneNumber= x.PhoneNumber,
                                Nationality= x.Nationality,
                                TicketType= x.TicketType,
                                Email= x.Email,
                                FlightId= x.FlightId,
                                Flights= x.Flights,

                            })
                            .ToListAsync();

            model.ElementsCount = this.context.Reservations.Count();

            return model;
        }

        
    }
}