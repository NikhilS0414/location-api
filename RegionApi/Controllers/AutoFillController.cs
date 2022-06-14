using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Region.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegionApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoFillController : ControllerBase
    {
        private readonly ILogger<AutoFillController> _logger;
        private readonly IAutoFillService _autoFillService;

        public AutoFillController(ILogger<AutoFillController> logger, IAutoFillService autoFillService)
        {
            _logger = logger;
            _autoFillService = autoFillService;
        }

        // Autocomplete postal code.
        [HttpGet]
        public async Task<List<string>> GetPostalCodes(string postCode)
        {
            _logger.LogTrace("Get Post codes.", postCode);
            
            List<string>  postalDetails = await _autoFillService.GetPostalCodes(postCode);

            return postalDetails;
        }
    }
}
