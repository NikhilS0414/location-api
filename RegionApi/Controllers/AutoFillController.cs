using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Region.Data.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RegionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoFillController : ControllerBase
    {
        private readonly ILogger<AutoFillController> _logger;

        public AutoFillController(ILogger<AutoFillController> logger)
        {
            _logger = logger;
        }

        // Autocomplete postal code.
        [HttpGet]
        public async Task<List<string>> GetPostalCodes(string postCode)
        {

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var api = "https://postcodes.io/postcodes/" + postCode + "/autocomplete";
            var response = await client.GetAsync(api);
            response.EnsureSuccessStatusCode();
            var dsResponse = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dsResponse);
            List<string> postalDetails = new List<string>();
            dynamic list = values["result"].ToString();
            postalDetails.Add(list.ToString());
            
            return postalDetails;
        }
    }
}
