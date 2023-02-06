using Newtonsoft.Json;

namespace CarListApp.Services.Api
{
    public abstract class ApiServiceBase
    {
        public static string BaseAddress = "https://car-list-api.onrender.com/";
        protected readonly HttpClient HttpClient;

        protected ApiServiceBase(TokenManager tokenManager)
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };

            tokenManager.TokenObtained += OnTokenChanged;
        }

        private void OnTokenChanged(object sender, AuthData e)
        {
            const string bearerHeaderName = "Bearer";
            HttpClient.DefaultRequestHeaders.Remove(bearerHeaderName);
            HttpClient.DefaultRequestHeaders.Add(bearerHeaderName, e.AccessToken);
        }

        protected async Task<TResult> GetFromJsonAsync<TResult>(string path)
        {
            var response = await HttpClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(contentString);
        }
    }
}
