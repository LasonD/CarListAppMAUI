using Newtonsoft.Json;

namespace CarListApp.Services.Api
{
    public abstract class ApiServiceBase
    {
        public static string BaseAddress = "https://carlistapp-sbarylo20023.b4a.run/";

        protected readonly HttpClient HttpClient;

        protected ApiServiceBase()
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseAddress)
            };
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
