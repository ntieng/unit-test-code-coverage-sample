using Coffee.Api.Models;
using Newtonsoft.Json;

namespace Coffee.Api.Services
{
    public class CoffeeService : IBackendService
    {
        private readonly HttpClient _httpClient;

        public CoffeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CoffeeResponseModel?> GetNew<CoffeeResponseModel>(CancellationToken cancellationToken = default)
        {
            _httpClient.BaseAddress = new Uri("https://api.sampleapis.com");
            var responseMessage = await _httpClient.GetAsync("/coffee/hot/1", cancellationToken);
            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<CoffeeResponseModel>(stream);
            }
            return default(CoffeeResponseModel);
        }
    }
}
