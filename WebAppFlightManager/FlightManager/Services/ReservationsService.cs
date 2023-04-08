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
    public class ReservationsService : IReservationService
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

            };

            await this.context.Reservations.AddAsync(reservation);
            await this.context.SaveChangesAsync();
        }

        public Task DeleteReservationAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<DetailsReservationViewModel> GetReservationDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IndexReservationViewModel> GetReservationsAsync(IndexReservationsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}