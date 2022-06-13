using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Region.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [HttpGet]
        public async Task<LocationDetails> GetAsync(string postalCode)
        {

            var details = new LocationDetails();
            var api = "https://postcodes.io/postcodes/" + postalCode;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(api))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    details = JsonConvert.DeserializeObject<LocationDetails>(apiResponse);
                }
            }

            return details;
            
        }
    }
}
