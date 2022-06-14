using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Region.Entities;
using Region.Service;
using System.Threading.Tasks;

namespace RegionApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _locationService;

        public LocationController(ILogger<LocationController> logger, ILocationService locationService)
        {
            _logger = logger;
            _locationService = locationService;
        }

        // Lookup postal details.
        [HttpGet]
        public async Task<LocationDetails> GetAsync(string postalCode)
        {
            _logger.LogTrace("Get Postal Details for postal code", postalCode);

            LocationDetails details = await _locationService.GetAsync(postalCode);

            return details;
        }
    }
}
