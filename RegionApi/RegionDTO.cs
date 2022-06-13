using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegionApi
{
    public class RegionDTO
    {
        public string Country { get; set; }
        public string RegionName { get; set; }
        public string Admin_District { get; set; }
        public string Parliamentary_Constituency { get; set; }
        public float Area { get; set; }
    }
}
