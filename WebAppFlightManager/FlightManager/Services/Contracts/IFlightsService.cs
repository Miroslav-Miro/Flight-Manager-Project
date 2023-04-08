using FlightManager.ViewModels.Flights;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IFlightsService
    {
        Task CreateFlightAsync(CreateFlightViewModel model);

        Task DeleteFlightAsync(string id);

        Task<IndexFlightsViewModel> GetFlightsAsync(IndexFlightsViewModel model);

        Task<DetailsFlightViewModel> GetFlightDetails(string id);

        Task EditFlightByAdminAsync(EditFlightViewModel model);

        Task<EditFlightViewModel> GetFlightToEditAsync(string id);

        Task<SelectList> GetPilotsSelectListAsync();

    }
}