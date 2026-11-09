
using System.Net.Http.Json;

namespace RaceDayMVC.Services
{
    public class RaceDayApiService
    {
        private readonly HttpClient _httpClient;

        public RaceDayApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: Retrieve all records
        public async Task<List<T>> GetAllAsync<T>(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<List<T>>(endpoint)
                   ?? new List<T>();
        }

        // GET: Retrieve one record by ID
        public async Task<T?> GetByIdAsync<T>(string endpoint, string id)
        {
            return await _httpClient.GetFromJsonAsync<T>(
                $"{endpoint}/{Uri.EscapeDataString(id)}");
        }

        // POST: Add a new record
        public async Task<bool> CreateAsync<T>(string endpoint, T model)
        {
            var response = await _httpClient.PostAsJsonAsync(
                endpoint, model);

            return response.IsSuccessStatusCode;
        }

        // PUT: Update an existing record
        public async Task<bool> UpdateAsync<T>(
            string endpoint, string id, T model)
        {
            var response = await _httpClient.PutAsJsonAsync(
                $"{endpoint}/{Uri.EscapeDataString(id)}", model);

            return response.IsSuccessStatusCode;
        }

        // DELETE: Remove a record
        public async Task<bool> DeleteAsync(string endpoint, string id)
        {
            var response = await _httpClient.DeleteAsync(
                $"{endpoint}/{Uri.EscapeDataString(id)}");

            return response.IsSuccessStatusCode;
        }
    }
}

