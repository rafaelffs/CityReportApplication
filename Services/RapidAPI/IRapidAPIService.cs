using CityReportApplication.Model;
using CityReportApplication.ViewModel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CityReportApplication.Services.RapidAPI
{
    public interface IRapidAPIService
    {
        Task<Location> GetCity(string city);
        Task<Astronomy> GetAstronomy(string city);
        Task<CurrentCondition> GetCurrentCondition(string city);
    }
}
