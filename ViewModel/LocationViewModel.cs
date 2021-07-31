using CityReportApplication.Model;
using CityReportApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CityReportApplication.ViewModel
{
    public class LocationViewModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string CurrentDateTime { get; set; }
        public CurrentConditionViewModel CurrentCondition { get; set; }
        public AstronomyViewModel Astronomy { get; set; }
    }
}
