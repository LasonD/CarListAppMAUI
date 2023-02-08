using System.Net;
using System.Net.Http.Json;
using CarListApp.Models;

namespace CarListApp.Services.Api;

public class CarApiService : ApiServiceBase
{
    public CarApiService(PersistedTokenManager persistedTokenManager) : base(persistedTokenManager)
    {
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
        await SetInitialTokenTask;

        var response = await HttpClient.PostAsJsonAsync("cars", car);

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
        await SetInitialTokenTask;

        var response = await HttpClient.PutAsJsonAsync($"cars/{id}", car);

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
        await SetInitialTokenTask;

        var response = await HttpClient.DeleteAsync($"cars/{id}");

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