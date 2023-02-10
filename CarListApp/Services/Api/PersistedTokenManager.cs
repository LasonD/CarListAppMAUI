using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;

namespace CarListApp.Services.Api
{
    public class PersistedTokenManager
    {
        private const int TokenExpOffsetMin = 3;
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

            var authData = JsonConvert.DeserializeObject<AuthData>(tokenJson);

            if (authData == null)
            {
                return null;
            }

            if (!IsTokenValid(authData.AccessToken))
            {
                SecureStorage.Remove(TokenKey);
                return null;
            }

            return authData;
        }

        public static bool IsTokenValid(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenExpirationDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            return tokenExpirationDate >= DateTime.UtcNow.AddMinutes(TokenExpOffsetMin);
        }

        public static long GetTokenExpirationTime(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals(JwtRegisteredClaimNames.Exp)).Value;
            var ticks = long.Parse(tokenExp);

            return ticks;
        }
    }
}
