using Musicalia.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace Musicalia.Services.Classes
{
    public class TokenService : ITokenService
    {
        private readonly string _clientId;
        private readonly string _clientSecret;

        private string? _token;
        private DateTime _expirationTime;        

        public TokenService(IConfiguration configuration) 
        {
            _clientId = configuration["SpotifySecrets:CLIENT_ID"]!;
            _clientSecret = configuration["SpotifySecrets:CLIENT_SECRET"]!;
        }

        public async Task<string> GetTokenAsync()
        {
            if (string.IsNullOrEmpty(_token) || DateTime.UtcNow >= _expirationTime)
            {
                _token = await GenerateTokenAsync();
                _expirationTime = DateTime.UtcNow.AddHours(1);
            }

            return _token;
        }

        private async Task<string> GenerateTokenAsync()
        {
            string url = "https://accounts.spotify.com/api/token";
            string clientCredentials = "grant_type=client_credentials";


            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _clientId, _clientSecret)));

            HttpClient client = new HttpClient();

            try
            {
                var content = new StringContent(clientCredentials, Encoding.ASCII, "application/x-www-form-urlencoded");

                client.DefaultRequestHeaders.Add("Authorization", "Basic " + encode_clientid_clientsecret);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsync(url, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                JsonDocument doc = JsonDocument.Parse(responseBody);
                string accessToken = doc.RootElement.GetProperty("access_token").GetString()!;

                return accessToken;

            }
            catch (HttpRequestException)
            {
                return string.Empty;
            }
        }
    }
}
