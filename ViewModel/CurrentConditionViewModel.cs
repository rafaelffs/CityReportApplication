using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.ViewModel
{
    public class CurrentConditionViewModel
    {
        public double Temperature { get; set; }
        public string WeatherCondition { get; set; }
        public string WeatherIcon { get; set; }
    }
}
