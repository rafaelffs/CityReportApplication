using CityReportApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.Model
{
    public class AstronomyBase
    {
        [JsonPropertyName("astronomy")]
        public AstroBase AstroBase { get; set; } = new AstroBase();
    }
    public class AstroBase
    {
        [JsonPropertyName("astro")]
        public Astronomy Astronomy { get; set; } = new Astronomy();
    }
    public class Astronomy
    {
        [JsonConverter(typeof(TimeSpanJSONConverter))]
        [JsonPropertyName("sunrise")]
        public TimeSpan Sunrise { get; set; }
        [JsonConverter(typeof(TimeSpanJSONConverter))]
        [JsonPropertyName("sunset")]
        public TimeSpan Sunset { get; set; }
        [JsonPropertyName("moon_phase")]
        public string MoonPhase { get; set; }
    }
}
