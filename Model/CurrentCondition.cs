using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.Model
{
    public class CurrentConditionBase
    {
        [JsonPropertyName("current")]
        public CurrentCondition CurrentCondition { get; set; } = new CurrentCondition();
    }

    public class Condition
    {
        [JsonPropertyName("text")]
        public string WeatherCondition { get; set; }
        [JsonPropertyName("icon")]
        public string WeatherIcon { get; set; }
    }

    public class CurrentCondition
    {
        [JsonPropertyName("temp_c")]
        public double Temperature { get; set; }
        public Condition Condition { get; set; }

    }
}
