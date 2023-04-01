namespace FlightManager.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using FlightManager.Data;
    using FlightManager.Models;
    using FlightManager.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService:IUsersService
    {
        private ApplicationDbContext context;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UsersService(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task DeleteUserByIdAsync(string id)
        {
            User user = await this.userManager.FindByIdAsync(id);

            await this.userManager.DeleteAsync(user);
        }

        public async Task CreateUserAsync(CreateUserViewModel model)
        {
            User user = new User()
            {
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                NormalizedEmail = model.Email,
                UserName = model.Email,
                NormalizedUserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
            };

            await this.userManager.CreateAsync(user, model.Password);
        }

        public async Task<EditUserViewModel> GetUserToEditByIdAsync(string id)
        {
            User user = await this.context.Users.FindAsync(id);
            EditUserViewModel model = null;
            if (user != null)
            {
                model = new EditUserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };
            }

            return model;
        }

        public async Task<UserViewModel> GetUserByIdAsync(string id)
        {
            User user = await this.context.Users.FindAsync(id);

            UserViewModel model = null;

            if (user != null)
            {
                model = new UserViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };
            }

            return model;
        }

        public async Task<UsersViewModel> GetUsersAsync(int page = 1, int count = 10)
        {
            UsersViewModel model = new UsersViewModel();

            model.ItemsPerPage = count;
            model.Page = page;
            model.ElementsCount = await this.context.Users.CountAsync();

            model.Users = await this.context.Users
                  .Skip((page - 1) * count)
                  .Take(count)
                  .Select(x => new UserViewModel()
                  {
                      Id = x.Id,
                      FirstName = x.FirstName,
                      LastName = x.LastName,
                      Email = x.Email,
                  })
              .ToListAsync();

            return model;
        }

    }
}
