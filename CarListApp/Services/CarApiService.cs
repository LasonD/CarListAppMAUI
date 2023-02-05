using System.Net;
using System.Net.Http.Json;
using CarListApp.Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace CarListApp.Services
{
    public class CarApiService
    {
        public static string BaseAddress = "https://car-list-api.onrender.com/";
        private readonly HttpClient _httpClient;

        public CarApiService()
        {
            _httpClient= new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            var response = await _httpClient.GetAsync("cars");

            response.EnsureSuccessStatusCode();

            var contentString =  await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<Car>>(contentString);
        }

        public async Task<Car> GetCarAsync(int id)
        {
            var response = await _httpClient.GetAsync($"cars/{id}");

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Car>(contentString);
        }

        public async Task<bool> AddCarAsync(Car car)
        {
            var response = await _httpClient.PostAsJsonAsync("cars", car);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK or HttpStatusCode.Created:
                    return true;
                case HttpStatusCode.NotFound:
                    return false;
                default:
                    response.EnsureSuccessStatusCode();
                    return false;
            }
        }

        public async Task<bool> UpdateCarAsync(int id, Car car)
        {
            var response = await _httpClient.PutAsJsonAsync($"cars/{id}", car);

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK or HttpStatusCode.Created:
                    return true;
                case HttpStatusCode.NotFound:
                    return false;
                default:
                    response.EnsureSuccessStatusCode();
                    return false;
            }
        }

        public async Task<bool> DeleteCarAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cars/{id}");

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK or HttpStatusCode.NoContent:
                    return true;
                case HttpStatusCode.NotFound:
                    return false;
                default:
                    response.EnsureSuccessStatusCode();
                    return false;
            }
        }
    }
}
