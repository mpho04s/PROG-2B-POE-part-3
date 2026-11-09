
using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class ParticipantProfilesController : Controller
    {
        private readonly RaceDayApiService _apiService;

        public ParticipantProfilesController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        private const string Endpoint = "api/ParticipantProfiles";

        public async Task<IActionResult> Index()
        {
            try
            {
                var profiles = await _apiService.GetAllAsync<ParticipantProfile>(Endpoint);
                return View(profiles);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var profile = await _apiService.GetByIdAsync<ParticipantProfile>(Endpoint, id);

                if (profile == null)
                {
                    return NotFound();
                }

                return View(profile);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParticipantProfile profile)
        {
            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            try
            {
                bool result = await _apiService.CreateAsync(Endpoint, profile);

                if (result)
                {
                    TempData["Success"] = "Participant profile created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Unable to create participant profile.");
                return View(profile);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var profile = await _apiService.GetByIdAsync<ParticipantProfile>(Endpoint, id);

                if (profile == null)
                {
                    return NotFound();
                }

                return View(profile);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ParticipantProfile profile)
        {
            if (id != profile.ProfileID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(profile);
            }

            try
            {
                bool result = await _apiService.UpdateAsync(Endpoint, id, profile);

                if (result)
                {
                    TempData["Success"] = "Participant profile updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Unable to update participant profile.");
                return View(profile);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var profile = await _apiService.GetByIdAsync<ParticipantProfile>(Endpoint, id);

                if (profile == null)
                {
                    return NotFound();
                }

                return View(profile);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                bool result = await _apiService.DeleteAsync(Endpoint, id);

                if (result)
                {
                    TempData["Success"] = "Participant profile deleted successfully.";
                }
                else
                {
                    TempData["Error"] = "Unable to delete participant profile.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }
    }
}

