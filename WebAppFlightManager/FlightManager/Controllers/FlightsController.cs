namespace FlightManager.Controllers
{
    using System.Data;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using FlightManager.Services.Contracts;
    using FlightManager.ViewModels.Flights;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class FlightsController : Controller
    {
        private readonly IFlightsService flightsService;

        public FlightsController(IFlightsService flightsService)
        {
            this.flightsService = flightsService;
        }

        public async Task<IActionResult> Index(IndexFlightsViewModel model)
        {
            model = await this.flightsService.GetFlightsAsync(model);

            return this.View(model);
        }

        // GET: Create
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            CreateFlightViewModel model = new CreateFlightViewModel();
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.TimeTakeOf = System.DateTime.Now;
            return this.View(model);
        }

        // [Authorize(Roles = "Admin")]
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
    }
}
