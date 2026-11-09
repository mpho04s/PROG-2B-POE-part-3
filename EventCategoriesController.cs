
using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class EventCategoriesController : Controller
    {
        private readonly RaceDayApiService _apiService;

        private const string Endpoint = "api/EventCategories";

        public EventCategoriesController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        // Display all event categories
        public async Task<IActionResult> Index()
        {
            try
            {
                var categories =
                    await _apiService.GetAllAsync<EventCategory>(Endpoint);

                return View(categories);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display category details
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var category =
                    await _apiService.GetByIdAsync<EventCategory>(
                        Endpoint, id.ToString());

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
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

        // Create a new category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                bool result =
                    await _apiService.CreateAsync(Endpoint, category);

                if (result)
                {
                    TempData["Success"] =
                        "Event category created successfully.";

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "", "Unable to create the event category.");

                return View(category);
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
                var category =
                    await _apiService.GetByIdAsync<EventCategory>(
                        Endpoint, id.ToString());

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Update an existing category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id, EventCategory category)
        {
            if (id != category.CategoryID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            try
            {
                bool result =
                    await _apiService.UpdateAsync(
                        Endpoint, id.ToString(), category);

                if (result)
                {
                    TempData["Success"] =
                        "Event category updated successfully.";

                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    "", "Unable to update the event category.");

                return View(category);
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
                var category =
                    await _apiService.GetByIdAsync<EventCategory>(
                        Endpoint, id.ToString());

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Delete the selected category
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
                        "Event category deleted successfully.";
                }
                else
                {
                    TempData["Error"] =
                        "Unable to delete the event category.";
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

