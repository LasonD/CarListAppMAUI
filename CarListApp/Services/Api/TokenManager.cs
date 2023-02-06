using Newtonsoft.Json;

namespace CarListApp.Services.Api
{
    public class TokenManager
    {
        private const string TokenKey = "Token";

        public event EventHandler<AuthData> TokenObtained;

        public async Task SetTokenAsync(AuthData authData)
        {

            await SecureStorage.SetAsync(TokenKey, JsonConvert.SerializeObject(authData));
            TokenObtained?.Invoke(this, authData);
        }

        public async Task<AuthData> GetTokenAsync()
        {
            var tokenJson = await SecureStorage.GetAsync(TokenKey);

            if (tokenJson == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<AuthData>(tokenJson);
        }
    }
}
