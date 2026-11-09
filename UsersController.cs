using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly RaceDayApiService _apiService;

        public UsersController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _apiService.GetAllAsync<Users>(
                "api/Users");

            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _apiService.GetByIdAsync<Users>(
                "api/Users", id.ToString());

            if (user == null)
                return NotFound();

            return View(user);
        }
    }
}
