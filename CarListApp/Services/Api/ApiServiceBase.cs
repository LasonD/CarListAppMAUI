using Newtonsoft.Json;

namespace CarListApp.Services.Api
{
    public abstract class ApiServiceBase : IDisposable
    {
        public static string BaseAddress = "https://car-list-api.onrender.com/";

        protected readonly HttpClient HttpClient;
        protected readonly PersistedTokenManager PersistedTokenManager;
        protected readonly Task SetInitialTokenTask;

        protected ApiServiceBase(PersistedTokenManager persistedTokenManager)
        {
            PersistedTokenManager = persistedTokenManager;
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };

            persistedTokenManager.TokenObtained += OnTokenChanged;
            SetInitialTokenTask = SetupTokenAsync();
        }

        private async Task SetupTokenAsync()
        {
            var tokenData = await PersistedTokenManager.GetTokenAsync();
            SetAccessToken(tokenData.AccessToken);
        }

        private void OnTokenChanged(object sender, AuthData e)
        {
            SetAccessToken(e.AccessToken);
        }

        private void SetAccessToken(string accessToken)
        {
            const string bearerHeaderName = "Bearer";
            HttpClient.DefaultRequestHeaders.Remove(bearerHeaderName);
            HttpClient.DefaultRequestHeaders.Add(bearerHeaderName, accessToken);
        }

        protected async Task<TResult> GetFromJsonAsync<TResult>(string path)
        {
            await SetInitialTokenTask;

            var response = await HttpClient.GetAsync(path);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResult>(contentString);
        }

        public void Dispose()
        {
            HttpClient?.Dispose();
            PersistedTokenManager.TokenObtained -= OnTokenChanged;
        }
    }
}
