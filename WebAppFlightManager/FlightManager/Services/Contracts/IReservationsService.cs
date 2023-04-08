using FlightManager.Models;
using FlightManager.ViewModels.Reservations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IReservationsService
    {

        Task CreateReservationAsync(CreateReservationViewModel model);

        Task DeleteReservationAsync(string id);

        Task<IndexReservationsViewModel> GetReservationsAsync(IndexReservationsViewModel model);

        Task<DetailsReservationViewModel> GetReservationDetails(string id);


    }
}