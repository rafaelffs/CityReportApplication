using CityReportApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.Model
{
    public class LocationBase
    {

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new Location();
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
        [JsonPropertyName("localtime")]
        [JsonConverter(typeof(DateTimeJSONConverter))]
        public DateTime CurrentDateTime { get; set; }
        public CurrentCondition CurrentCondition { get; set; }
        public Astronomy Astronomy { get; set; }

    }
}
