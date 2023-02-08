using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CarListApp.Services.Api;

public class AuthApiService : ApiServiceBase
{
    public AuthApiService(PersistedTokenManager persistedTokenManager) : base(persistedTokenManager)
    {
    }

    public async Task<AuthData> LoginAsync(string username, string password)
    {
        var response = await HttpClient.PostAsJsonAsync("/login", new { Username = username, Password = password });

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        var authData = JsonConvert.DeserializeObject<AuthData>(responseString);

        await PersistedTokenManager.SetTokenAsync(authData);

        return authData;
    }
}

public class AuthData
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string AccessToken { get; set; }
}