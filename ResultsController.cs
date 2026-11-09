using Microsoft.AspNetCore.Mvc;
using RaceDayMVC.Models;
using RaceDayMVC.Services;

namespace RaceDayMVC.Controllers
{
    public class ResultsController : Controller
    {
        private readonly RaceDayApiService _apiService;

        public ResultsController(RaceDayApiService apiService)
        {
            _apiService = apiService;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            try
            {
                var results = await _apiService.GetAllAsync<Result>(
                    "api/Results");

                return View(results);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // GET: Results/Details/1
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _apiService.GetByIdAsync<Result>(
                    "api/Results", id.ToString());

                if (result == null)
                {
                    return NotFound();
                }

                return View(result);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Results/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Result result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            try
            {
                bool success = await _apiService.CreateAsync(
                    "api/Results", result);

                if (success)
                {
                    TempData["Success"] = "Result created successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    string.Empty, "Unable to create the result.");

                return View(result);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // GET: Results/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _apiService.GetByIdAsync<Result>(
                    "api/Results", id.ToString());

                if (result == null)
                {
                    return NotFound();
                }

                return View(result);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // POST: Results/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Result result)
        {
            if (id != result.ResultID)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(result);
            }

            try
            {
                bool success = await _apiService.UpdateAsync(
                    "api/Results", id.ToString(), result);

                if (success)
                {
                    TempData["Success"] = "Result updated successfully.";
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(
                    string.Empty, "Unable to update the result.");

                return View(result);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // GET: Results/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _apiService.GetByIdAsync<Result>(
                    "api/Results", id.ToString());

                if (result == null)
                {
                    return NotFound();
                }

                return View(result);
            }
            catch (HttpRequestException)
            {
                return View("ApiError");
            }
        }

        // POST: Results/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                bool success = await _apiService.DeleteAsync(
                    "api/Results", id.ToString());

                if (success)
                {
                    TempData["Success"] = "Result deleted successfully.";
                }
                else
                {
                    TempData["Error"] = "Unable to delete the result.";
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
