
using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class EnrolmentsController : Controller
    {
        private readonly RaceDayApiService _apiService;

        private const string Endpoint = "api/Enrolments";

        public EnrolmentsController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        // Display all enrolments
        public async Task<IActionResult> Index()
        {
            try
            {
                var enrolments =
                    await _apiService.GetAllAsync<Enrolment>(Endpoint);

                return View(enrolments);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display one enrolment
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var enrolment =
                    await _apiService.GetByIdAsync<Enrolment>(
                        Endpoint, id.ToString());

                if (enrolment == null)
                {
                    return NotFound();
                }

                return View(enrolment);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display create form
        public IActionResult Create()
        {
            return View();
        }

        // Create a new enrolment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrolment enrolment)
        {
            if (!ModelState.IsValid)
            {
                return View(enrolment);
            }

            try
            {
                bool result =
                    await _apiService.CreateAsync(Endpoint, enrolment);

                if (result)
                {
                    TempData["Success"] =
                        "Enrolment created successfully.";

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "", "Unable to create the enrolment.");

                return View(enrolment);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display edit form
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var enrolment =
                    await _apiService.GetByIdAsync<Enrolment>(
                        Endpoint, id.ToString());

                if (enrolment == null)
                {
                    return NotFound();
                }

                return View(enrolment);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Update an existing enrolment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, Enrolment enrolment)
        {
            if (id != enrolment.EnrolmentID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(enrolment);
            }

            try
            {
                bool result =
                    await _apiService.UpdateAsync(
                        Endpoint, id.ToString(), enrolment);

                if (result)
                {
                    TempData["Success"] =
                        "Enrolment updated successfully.";

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "", "Unable to update the enrolment.");

                return View(enrolment);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display delete confirmation
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var enrolment =
                    await _apiService.GetByIdAsync<Enrolment>(
                        Endpoint, id.ToString());

                if (enrolment == null)
                {
                    return NotFound();
                }

                return View(enrolment);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Delete the selected enrolment
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                bool result =
                    await _apiService.DeleteAsync(
                        Endpoint, id.ToString());

                if (result)
                {
                    TempData["Success"] =
                        "Enrolment deleted successfully.";
                }
                else
                {
                    TempData["Error"] =
                        "Unable to delete the enrolment.";
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
