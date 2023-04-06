namespace FlightManager.Web.Controllers
{
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using FlightManager.Models;
    using FlightManager.Services.Contracts;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services;
    using ViewModels.Users;

    // [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(
            IUsersService usersService)
        {
            this.usersService = usersService;
        }

        // GET: Users
        public async Task<IActionResult> Index(int page = 1, int itemsPerPage = 10)
        {
            var model = await usersService.GetUsersAsync(page, itemsPerPage);
            return View(model);
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await usersService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await usersService.CreateUserAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await usersService.GetUserToEditByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditUserViewModel user)
        {
            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await usersService.UpdateUserAsync(user);

                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await usersService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await usersService.DeleteUserByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}