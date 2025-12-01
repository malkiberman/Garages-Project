using Garages.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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

        [HttpGet("LoadFromGov")]
        public async Task<IActionResult> LoadFromGov()
        {
            var response = await _httpClient.GetStringAsync(GovApiUrl);

            var json = JsonDocument.Parse(response);
            var records = json.RootElement
                               .GetProperty("result")
                               .GetProperty("records");

            var garagesList = new List<Data.Garage>();

            foreach (var record in records.EnumerateArray())
            {
                var garage = new Data.Garage
                {
                    MisparMosah = record.GetProperty("mispar_mosah").GetInt32(),
                    ShemMosah = record.GetProperty("shem_mosah").GetString(),
                    CodSugMosah = record.GetProperty("cod_sug_mosah").GetInt32(),
                    SugMosah = record.GetProperty("sug_mosah").GetString(),
                    Ktovet = record.GetProperty("ktovet").GetString(),
                    Yishuv = record.GetProperty("yishuv").GetString(),
                    Telephone = record.GetProperty("telephone").GetString(),
                    Mikud = record.GetProperty("mikud").GetInt32(),
                    CodMiktzoa = record.GetProperty("cod_miktzoa").GetInt32(),
                    Miktzoa = record.GetProperty("miktzoa").GetString(),
                    MenahelMiktzoa = record.GetProperty("menahel_miktzoa").GetString(),
                    RashamHavarot = record.GetProperty("rasham_havarot").GetInt32()
                };

                garagesList.Add(garage);

                
            }

            return Ok(garagesList); 
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
