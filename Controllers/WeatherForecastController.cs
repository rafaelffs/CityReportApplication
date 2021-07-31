using AutoMapper;
using CityReportApplication.Model;
using CityReportApplication.Services.WeatherForecast;
using CityReportApplication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityReportApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly IMapper _mapper;

        public WeatherForecastController(IWeatherForecastService weatherForecastService, IMapper mapper)
        {
            _weatherForecastService = weatherForecastService;
            _mapper = mapper;
        }

        [HttpGet("GetLocation")]
        public async Task<LocationViewModel> GetLocation(string city)
        {
            Location location = await _weatherForecastService.GetCity(city);
            return _mapper.Map<LocationViewModel>(location);
        }

        [HttpGet("GetCurrentCondition")]
        public async Task<CurrentConditionViewModel> GetCurrentCondition(string city)
        {
            CurrentCondition currentCondition = await _weatherForecastService.GetCurrentCondition(city);
            return _mapper.Map<CurrentConditionViewModel>(currentCondition);
        }

        [HttpGet("GetAstronomy")]
        public async Task<AstronomyViewModel> GetAstronomy(string city)
        {
            Astronomy astronomy = await _weatherForecastService.GetAstronomy(city);
            return _mapper.Map<AstronomyViewModel>(astronomy);
        }

        [HttpGet("GetAllCities")]
        public string[] GetAllCities()
        {
            return _weatherForecastService.GetAllCities();
        }
        [HttpGet("GetCityCompleteData")]
        public async Task<LocationViewModel> GetCityCompleteData(string city)
        {
            Location location = await _weatherForecastService.GetCityCompleteData(city);
            LocationViewModel locationViewModel = _mapper.Map<LocationViewModel>(location);
            return locationViewModel;
        }



    }
}
