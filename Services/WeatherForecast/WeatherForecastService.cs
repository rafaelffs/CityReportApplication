using AutoMapper;
using CityReportApplication.Model;
using CityReportApplication.Services.RapidAPI;
using CityReportApplication.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityReportApplication.Services.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IRapidAPIService _rapidAPIService;

        public WeatherForecastService(IRapidAPIService rapidAPIService)
        {
            this._rapidAPIService = rapidAPIService;
        }
        public async Task<Location> GetCity(string city)
        {
            Location location = await _rapidAPIService.GetCity(city);
            return location;
        }
        public async Task<CurrentCondition> GetCurrentCondition(string city)
        {
            CurrentCondition currentCondition = await _rapidAPIService.GetCurrentCondition(city);
            return currentCondition;
        }
        public async Task<Astronomy> GetAstronomy(string city)
        {
            Astronomy astronomy = await _rapidAPIService.GetAstronomy(city);
            return astronomy;
        }

        public string[] GetAllCities()
        {
            string[] cities = { "Beijing", "Nairobi", "New York", "Mumbai", "Paris", "Sydney" };
            return cities;
        }

        public async Task<Location> GetCityCompleteData(string city)
        {
            Location location = await GetCity(city);
            Astronomy astronomy = await GetAstronomy(city);
            CurrentCondition currentCondition = await GetCurrentCondition(city);
            location.Astronomy = astronomy;
            location.CurrentCondition = currentCondition;
            return location;
        }
    }
}
