namespace FlightManager.ViewModels.Users
{
    using ViewModels.Shared;
    using System.Collections.Generic;
    public class UsersViewModel : PagingViewModel
    {
        public ICollection<UserViewModel> Users { get; set; }
    }
}
