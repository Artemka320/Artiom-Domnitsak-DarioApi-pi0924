using System.Net.Http;
using System.Threading.Tasks;

namespace projeto.Services
{
    public class ExternalService
    {
        private readonly HttpClient _httpClient;

        public ExternalService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetDataFromExternalApiAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}