using Coffee.Api.Models;
using Coffee.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Coffee.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeController : ControllerBase
    {
        private readonly ILogger<CoffeeController> _logger;
        private readonly IBackendService _backendService;

        public CoffeeController(ILogger<CoffeeController> logger,
        IBackendService backendService)
        {
            _logger = logger;
            _backendService = backendService;
        }

        [HttpGet(Name = "GetCoffee")]
        public async Task<CoffeeResponseModel?> Get()
        {
            var res = await _backendService.GetNew<CoffeeResponseModel>();

            if (res != null)
            {
                return new CoffeeResponseModel()
                {
                    title = res.title,
                    description = res.description,
                    ingredients = res.ingredients,
                    image = res.image,
                    id = res.id
                };
            }

            return null;
        }
    }
}
