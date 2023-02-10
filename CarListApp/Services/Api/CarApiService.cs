using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using CarListApp.Models;

namespace CarListApp.Services.Api;

public class CarApiService : ApiServiceBase
{
    private readonly PersistedTokenManager _persistedTokenManager;
    private readonly Task _setInitialTokenTask;

    public CarApiService(PersistedTokenManager persistedTokenManager)
    {
        _persistedTokenManager = persistedTokenManager;
        persistedTokenManager.TokenObtained += OnTokenChanged;
        _setInitialTokenTask = SetupTokenAsync();
    }

    private async Task SetupTokenAsync()
    {
        var tokenData = await _persistedTokenManager.GetTokenAsync();
        SetAccessToken(tokenData.AccessToken);
    }

    private void OnTokenChanged(object sender, AuthData e)
    {
        SetAccessToken(e.AccessToken);
    }

    private void SetAccessToken(string accessToken)
    {
        const string bearerHeaderName = "Bearer";
        HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(bearerHeaderName, accessToken);
    }

    public async Task<IEnumerable<Car>> GetCarsAsync()
    {
        await _setInitialTokenTask;
        return await GetFromJsonAsync<IEnumerable<Car>>("cars");
    }

    public async Task<Car> GetCarAsync(int id)
    {
        await _setInitialTokenTask;
        return await GetFromJsonAsync<Car>($"cars/{id}");
    }

    public async Task<bool> AddCarAsync(Car car)
    {
        await _setInitialTokenTask;

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
        await _setInitialTokenTask;

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
        await _setInitialTokenTask;

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