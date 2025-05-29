namespace IDF.Giminy_feutre
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class GeminiClient
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string apiKey;

        public GeminiClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<string> GenerateContentAsync(string prompt)
        {
            string url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={apiKey}";


            var body = new
            {
                contents = new[]
                {
            new {
                role = "user", 
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        }
            };

            var json = JsonSerializer.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, content);

            
            if (!response.IsSuccessStatusCode)
            {
                string error = await response.Content.ReadAsStringAsync();
                throw new Exception($" request faild (HTTP {response.StatusCode}): {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
