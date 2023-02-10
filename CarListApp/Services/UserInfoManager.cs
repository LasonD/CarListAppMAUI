using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CarListApp.Models;
using CarListApp.Services.Api;
using Newtonsoft.Json;

namespace CarListApp.Services
{
    public class UserInfoManager
    {
        private const int TokenExpOffsetMin = 3;
        private const string TokenKey = "Token";
        private const string UserInfoKey = "UserInfo";

        public event EventHandler<AuthData> TokenObtained;

        public async Task SetAuthDataAsync(AuthData authData)
        {
            await SecureStorage.SetAsync(TokenKey, JsonConvert.SerializeObject(authData));
            SetUserInfo(authData);
            TokenObtained?.Invoke(this, authData);
        }

        private void SetUserInfo(AuthData authData)
        {
            var jwt = DehydrateJwtToken(authData.AccessToken);

            var userInfo = new UserInfo()
            {
                Username = authData.Username,
                Roles = jwt.Claims.Where(c => c.Type.Equals(ClaimTypes.Role)).Select(c => c.Value).ToList(),
            };

            Preferences.Remove(UserInfoKey);
            Preferences.Set(UserInfoKey, JsonConvert.SerializeObject(userInfo));
        }

        public UserInfo GetUserInfo()
        {
            var raw = Preferences.Get(UserInfoKey, null);

            if (raw == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<UserInfo>(raw);
        }

        public async Task<string> GetAccessTokenAsync()
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

            return authData.AccessToken;
        }

        public static bool IsTokenValid(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenExpirationDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

            return tokenExpirationDate >= DateTime.UtcNow.AddMinutes(TokenExpOffsetMin);
        }

        private static long GetTokenExpirationTime(string token)
        {
            var jwt = DehydrateJwtToken(token);
            var tokenExp = jwt.Claims.First(claim => claim.Type.Equals(JwtRegisteredClaimNames.Exp)).Value;
            var ticks = long.Parse(tokenExp);

            return ticks;
        }

        private static JwtSecurityToken DehydrateJwtToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            return jwtSecurityToken;
        }
    }
}
