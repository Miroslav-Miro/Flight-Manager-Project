namespace FlightManager.Controllers
{
    using System.Data;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FlightManager.Common;
    using FlightManager.Services.Contracts;
    using FlightManager.ViewModels.Flights;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightsService flightsService;
        private readonly IUsersService usersService;

        public FlightsController(IFlightsService flightsService,IUsersService usersService )
        {
            this.flightsService = flightsService;
            this.usersService = usersService;
        }

        public async Task<IActionResult> Index(IndexFlightsViewModel model)
        {
            model = await this.flightsService.GetFlightsAsync(model);

            return this.View(model);
        }

        // GET: Create
        [Authorize(Roles = GlobalConstants.AdminRole)]
        public async Task<IActionResult> Create()
        {
            CreateFlightViewModel model = new CreateFlightViewModel();
            //string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.TimeTakeOf = System.DateTime.Now;
            model.Pilots = await this.usersService.GetAllUsersAsync();
            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.AdminRole)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFlightViewModel model)
        {
            model.UserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (this.ModelState.IsValid)
            {
                await this.flightsService.CreateFlightAsync(model);
                return this.RedirectToAction(nameof(this.Index));
            }
            model.Pilots = await this.usersService.GetUserSelectListAsync(model.UserId);
            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await this.flightsService.DeleteFlightAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Details(string id)
        {
            DetailsFlightViewModel model = await this.flightsService.GetFlightDetails(id);
            return this.View(model);
        }

        [Authorize(Roles = (GlobalConstants.AdminRole))]
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EditFlightViewModel model = await this.flightsService.GetFlightToEditAsync(id);
            return this.View(model);
        }

        [Authorize(Roles = (GlobalConstants.AdminRole))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFlightViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.flightsService.EditFlightByAdminAsync(model);
                return this.RedirectToAction(nameof(this.Index));
            }

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.Pilots = await this.flightsService.GetPilotsSelectListAsync();
            return this.View(model);
        }
    }
}
