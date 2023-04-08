using FlightManager.ViewModels.Shared;
using System.Collections.Generic;

namespace FlightManager.ViewModels.Reservations
{
    public class IndexReservationsViewModel : PagingViewModel
    {
        public ICollection<IndexReservationViewModel> Reservation { get; set; }

    }
}
