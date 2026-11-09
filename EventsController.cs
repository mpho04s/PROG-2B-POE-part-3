
using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly RaceDayApiService _apiService;

        private const string Endpoint = "api/Events";

        public EventsController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        // Display all events
        public async Task<IActionResult> Index()
        {
            try
            {
                var events = await _apiService.GetAllAsync<Event>(Endpoint);
                return View(events);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display one event
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var eventItem = await _apiService.GetByIdAsync<Event>(
                    Endpoint, id.ToString());

                if (eventItem == null)
                {
                    return NotFound();
                }

                return View(eventItem);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display the create form
        public IActionResult Create()
        {
            return View();
        }

        // Save a new event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            try
            {
                bool result = await _apiService.CreateAsync(
                    Endpoint, eventItem);

                if (result)
                {
                    TempData["Success"] = "Event created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Unable to create the event.");
                return View(eventItem);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display the edit form
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var eventItem = await _apiService.GetByIdAsync<Event>(
                    Endpoint, id.ToString());

                if (eventItem == null)
                {
                    return NotFound();
                }

                return View(eventItem);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Save changes to an event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Event eventItem)
        {
            if (id != eventItem.EventID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            try
            {
                bool result = await _apiService.UpdateAsync(
                    Endpoint, id.ToString(), eventItem);

                if (result)
                {
                    TempData["Success"] = "Event updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "Unable to update the event.");
                return View(eventItem);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Display the delete confirmation
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var eventItem = await _apiService.GetByIdAsync<Event>(
                    Endpoint, id.ToString());

                if (eventItem == null)
                {
                    return NotFound();
                }

                return View(eventItem);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // Delete the selected event
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                bool result = await _apiService.DeleteAsync(
                    Endpoint, id.ToString());

                if (result)
                {
                    TempData["Success"] = "Event deleted successfully.";
                }
                else
                {
                    TempData["Error"] = "Unable to delete the event.";
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

