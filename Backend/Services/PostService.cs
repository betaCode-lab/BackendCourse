using Backend.DTOs;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Backend.Services
{
    public class PostService : IPostService
    {
        private HttpClient _httpClient;

        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentNullException("Body was empty.");
            }

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            IEnumerable<PostDto> post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options)!;

            return post;
        }
    }
}
