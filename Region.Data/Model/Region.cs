using System;
using System.Collections.Generic;
using System.Text;

namespace Region.Data.Model
{
    public class Region
    {
        public string Country { get; set; }
        public string RegionName { get; set; }
        public string Admin_District { get; set; }
        public string Parliamentary_Constituency { get; set; }
        public float Area { get; set; }
    }
}
