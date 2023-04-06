using FlightManager.ViewModels.Flights;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IFlightsService
    {
        Task CreateFlightAsync(CreateFlightViewModel model);

        Task DeleteFlightAsync(string id);

        Task<IndexFlightsViewModel> GetFlightsAsync(IndexFlightsViewModel model);

        Task<DetailsFlightViewModel> GetFlightDetails(string id);
    }
}