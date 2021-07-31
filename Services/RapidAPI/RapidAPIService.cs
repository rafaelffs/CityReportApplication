using CityReportApplication.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CityReportApplication.Services.RapidAPI
{
    public class RapidAPIService : IRapidAPIService
    {
        public IHttpClientFactory _clientFactory { get; }
        public IConfiguration _config { get; }

        public RapidAPIService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<Location> GetCity(string city)
        {
            HttpRequestMessage httpRequestMessage = CreateRequestHeaders(_config, "timezone", city);
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);
            Location location = new Location();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                location = JsonSerializer.Deserialize
               <LocationBase>(content, new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true,
               }).Location;
            }
            return location;
        }

        public async Task<CurrentCondition> GetCurrentCondition(string city)
        {
            HttpRequestMessage httpRequestMessage = CreateRequestHeaders(_config, "current", city);
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);
            CurrentCondition currentCondition = new CurrentCondition();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                currentCondition = JsonSerializer.Deserialize
               <CurrentConditionBase>(content, new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true,
               }).CurrentCondition;
            }
            return currentCondition;
        }

        public async Task<Astronomy> GetAstronomy(string city)
        {
            HttpRequestMessage httpRequestMessage = CreateRequestHeaders(_config, "astronomy", city);
            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.SendAsync(httpRequestMessage);
            Astronomy astronomy = new Astronomy();

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                astronomy = JsonSerializer.Deserialize
               <AstronomyBase>(content, new JsonSerializerOptions
               {
                   PropertyNameCaseInsensitive = true,
               }).AstroBase.Astronomy;
            }
            return astronomy;
        }

        public static HttpRequestMessage CreateRequestHeaders(IConfiguration _config, string jsonName, string urlParameter)
        {
            string baseURL =
                _config.GetSection("WeatherAPI:BaseURL").Value;
            string keyName =
                _config.GetSection("WeatherAPI:KeyName").Value;
            string keyValue =
                _config.GetSection("WeatherAPI:KeyValue").Value;
            string hostName =
                _config.GetSection("WeatherAPI:HostName").Value;
            string hostValue =
                _config.GetSection("WeatherAPI:HostValue").Value;

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get,
                     baseURL + $"{jsonName}.json?q={urlParameter}");
            httpRequestMessage.Headers.Add(hostName, hostValue);
            httpRequestMessage.Headers.Add(keyName, keyValue);
            return httpRequestMessage;
        }

    }
}
