namespace FlightManager.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FlightManager.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public interface IUsersService
    {
        Task CreateUserAsync(CreateUserViewModel model);


        Task<UserViewModel> GetUserByIdAsync(string id);

        Task<UsersViewModel> GetUsersAsync(int page = 1, int count = 10);

        Task DeleteUserByIdAsync(string id);

        Task<EditUserViewModel> GetUserToEditByIdAsync(string id);

        Task UpdateUserAsync(EditUserViewModel model);

        Task<SelectList> GetUserSelectListAsync(string userId);
        Task<SelectList> GetAllUsersAsync();
    }
}