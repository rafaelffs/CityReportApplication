using AutoMapper;
using CityReportApplication.Model;
using CityReportApplication.Services.WeatherForecast;
using CityReportApplication.ViewModel;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Returns a location based on the input city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>LocationViewModel</returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetLocation")]
        public async Task<LocationViewModel> GetLocation(string city)
        {
            Location location = await _weatherForecastService.GetCity(city);
            return _mapper.Map<LocationViewModel>(location);
        }

        /// <summary>
        /// Returns the current condition based on the input city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>CurrentConditionViewModel</returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetCurrentCondition")]
        public async Task<CurrentConditionViewModel> GetCurrentCondition(string city)
        {
            CurrentCondition currentCondition = await _weatherForecastService.GetCurrentCondition(city);
            return _mapper.Map<CurrentConditionViewModel>(currentCondition);
        }

        /// <summary>
        /// Returns the astronomy based on the input city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>AstronomyViewModel</returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAstronomy")]
        public async Task<AstronomyViewModel> GetAstronomy(string city)
        {
            Astronomy astronomy = await _weatherForecastService.GetAstronomy(city);
            return _mapper.Map<AstronomyViewModel>(astronomy);
        }

        /// <summary>
        /// Returns the list of default cities
        /// </summary>
        /// <returns>string[]</returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllCities")]
        public string[] GetAllCities()
        {
            return _weatherForecastService.GetAllCities();
        }

        /// <summary>
        /// Returns a location based on the input city with current condition and astronomy data
        /// </summary>
        /// <param name="city"></param>
        /// <returns>LocationViewModel</returns>
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetCityCompleteData")]
        public async Task<LocationViewModel> GetCityCompleteData(string city)
        {
            Location location = await _weatherForecastService.GetCityCompleteData(city);
            LocationViewModel locationViewModel = _mapper.Map<LocationViewModel>(location);
            return locationViewModel;
        }



    }
}
