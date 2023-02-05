using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CarListApp.Models;

namespace CarListApp.Services
{
    public class CarApiService
    {
        public static string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:85" : "http://localhost:85";
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

            return JsonSerializer.Deserialize<IEnumerable<Car>>(contentString);
        }

        public async Task<Car> GetCarAsync(int id)
        {
            var response = await _httpClient.GetAsync($"cars/{id}");

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Car>(contentString);
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
