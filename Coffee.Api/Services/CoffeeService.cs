using Coffee.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            Temperature temperature = RandomTemperature();
            int number = RandomNumber();
            var responseMessage = await _httpClient.GetAsync($"/coffee/{temperature}/{number}", cancellationToken);
            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonConvert.DeserializeObject<CoffeeResponseModel>(stream);
            }
            return default(CoffeeResponseModel);
        }

        public Temperature RandomTemperature()
        {
            Random random = new Random();
            var temperatureList = Enum.GetValues(typeof(Temperature));
            return (Temperature)temperatureList.GetValue(random.Next(temperatureList.Length));
        }

        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(2, 6);
        }

        public enum Temperature
        {
            hot,
            iced
        }
    }
}
