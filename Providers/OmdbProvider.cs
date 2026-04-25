using System.Text.Json;
using MediaVault.Interfaces;
using MediaVault.Models;

namespace MediaVault.Providers
{
    public class OmdbProvider : IOmdbProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OmdbProvider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["OMDb:ApiKey"] ?? throw new InvalidOperationException("OMDb API key not configured.");
        }

        public async Task<OmdbSearchResult?> SearchByTitleAsync(string title)
        {
            var url = $"https://www.omdbapi.com/?t={Uri.EscapeDataString(title)}&apikey={_apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<OmdbSearchResult>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result?.Response != "True") return null;

            return result;
        }
    }
}