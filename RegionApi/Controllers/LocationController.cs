using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Region.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RegionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        // Lookup postal details.
        [HttpGet]
        public async Task<LocationDetails> GetAsync(string postalCode)
        {
    
            LocationDetails details = new LocationDetails();

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var api = "https://postcodes.io/postcodes/" + postalCode;
            var response = await client.GetAsync(api);
            response.EnsureSuccessStatusCode();
            var dsResponse = await response.Content.ReadAsStringAsync();
            
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dsResponse);
            
            details.Country = values["result"]["country"].ToString();
            details.Admin_district = values["result"]["admin_district"].ToString();
            details.Parliamentary_constituency = values["result"]["parliamentary_constituency"].ToString();
            details.Region = values["result"]["region"].ToString();

            float latitude = values["result"]["latitude"];
            if(latitude < 52.229466)
            {
                details.Area = "South";
            }
            else if(latitude >= 52.229466 && latitude < 53.27169)
            {
                details.Area = "Midlands";
            }
            else if(latitude >= 53.27169)
            {
                details.Area = "North";
            }

            return details;
        }
    }
}
