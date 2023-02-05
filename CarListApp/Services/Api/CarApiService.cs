using System.Net;
using System.Net.Http.Json;
using CarListApp.Models;

namespace CarListApp.Services.Api;

public class CarApiService : ApiServiceBase
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

    public Task<IEnumerable<Car>> GetCarsAsync()
    {
        return GetFromJsonAsync<IEnumerable<Car>>("cars");
    }

    public Task<Car> GetCarAsync(int id)
    {
        return GetFromJsonAsync<Car>($"cars/{id}");
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