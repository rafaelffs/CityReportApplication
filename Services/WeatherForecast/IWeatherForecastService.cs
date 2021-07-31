using CityReportApplication.Model;
using CityReportApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityReportApplication.Services.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<Location> GetCity(string city);
        Task<CurrentCondition> GetCurrentCondition(string city);
        Task<Astronomy> GetAstronomy(string city);
        string[] GetAllCities();
        Task<Location> GetCityCompleteData(string city);
    }
}
