using FlightManager.ViewModels.Shared;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Flights
{
    public class IndexFlightsViewModel : PagingViewModel
    {
        public ICollection<IndexFlightViewModel> Flights { get; set; }
    }
}
