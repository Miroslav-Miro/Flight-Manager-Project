using FlightManager.ViewModels.Flights;
using System.Threading.Tasks;

namespace FlightManager.Services.Contracts
{
    public interface IFlightsService
    {
        Task CreateFlightAsync(CreateFlightViewModel model);

        Task<IndexFlightsViewModel> GetFlightsAsync(IndexFlightsViewModel model);
    }
}