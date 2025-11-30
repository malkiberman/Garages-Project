using Garages.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Garages.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : Controller
    {
        private readonly IGarageRepo _garages;
        private readonly HttpClient _httpClient;

        private const string GovApiUrl =
    "https://data.gov.il/api/3/action/datastore_search?resource_id=bb68386a-a331-4bbc-b668-bba2766d517d&limit=5";

        public GarageController(IGarageRepo garages, HttpClient httpClient)
        {
            _garages = garages;
            _httpClient = httpClient;
        }


        [HttpGet("GetAllGarages")]
        public async Task<IActionResult> GetAllGarages()
        {
           var garages = await _garages.GetAllGaragesAsync();
            return Ok(garages);
        }
        [HttpPost("AddGarage")]
        public async Task<IActionResult> AddGarage([FromBody] Data.Garage garage)
        {
            await _garages.AddGarageAsync(garage);
            return Ok();
        }
    }
}
