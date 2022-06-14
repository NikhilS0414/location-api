using Newtonsoft.Json;

namespace Region.Entities
{
    public class LocationDetails
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("admin_district")]
        public string Admin_district { get; set; }

        [JsonProperty("parliamentary_constituency")]
        public string Parliamentary_constituency { get; set; }

        public string Area { get; set; }
    }
}
