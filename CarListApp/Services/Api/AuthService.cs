using Newtonsoft.Json;
using System.Net.Http.Json;

namespace CarListApp.Services.Api;

public class AuthService : ApiServiceBase
{
    public async Task<AuthData> Login(string username, string password)
    {
        var response = await HttpClient.PostAsJsonAsync("/login", new { Username = username, Password = password });

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<AuthData>(responseString);
    }
}

public class AuthData
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string AccessToken { get; set; }
}