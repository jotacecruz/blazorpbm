using System.Net.Http.Headers;
using System.Text.Json;
using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class TokenService
    {
        public AccessToken? AccessToken { get; private set; }
        public GoogleUserInfo? UserInfo { get; set; }

        public void SetAccessToken(string token)
        {
            AccessToken = JsonSerializer.Deserialize<AccessToken>(token, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public AccessToken? GetAccessToken()
        {
            return AccessToken;
        }
    }
}
