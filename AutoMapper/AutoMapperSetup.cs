using AutoMapper;
using CityReportApplication.Model;
using CityReportApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityReportApplication.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region .   ViewModel to Model   .

            CreateMap<LocationViewModel, Location>();
            CreateMap<CurrentConditionViewModel, CurrentCondition>()
                .ForMember(x => x.Condition,
                opt => opt.MapFrom(src => new Condition { WeatherCondition = src.WeatherCondition }))
                .ForMember(x => x.Condition,
                opt => opt.MapFrom(src => new Condition { WeatherIcon = src.WeatherIcon }));
            CreateMap<AstronomyViewModel, Astronomy>()
                    .ForMember(x => x.Sunrise,
                opt => opt.MapFrom(src => DateTime.Parse(src.Sunrise).TimeOfDay))
                    .ForMember(x => x.Sunset,
                opt => opt.MapFrom(src => DateTime.Parse(src.Sunset).TimeOfDay));

            #endregion

            #region .   Model to ViewModel   .

            CreateMap<Location, LocationViewModel>()
                .ForMember(x => x.CurrentDateTime,
                opt => opt.MapFrom(src => src.CurrentDateTime.ToString("yyyy-MM-dd HH:mm")));
            CreateMap<CurrentCondition, CurrentConditionViewModel>()
                .ForMember(x => x.WeatherCondition,
                opt => opt.MapFrom(src => src.Condition.WeatherCondition))
                .ForMember(x => x.WeatherIcon,
                opt => opt.MapFrom(src => src.Condition.WeatherIcon));
            CreateMap<Astronomy, AstronomyViewModel>()
                    .ForMember(x => x.Sunrise,
                opt => opt.MapFrom(src => DateTime.Today.Add(src.Sunrise).ToString("hh:mm tt")))
                    .ForMember(x => x.Sunset,
                opt => opt.MapFrom(src => DateTime.Today.Add(src.Sunset).ToString("hh:mm tt")));

            #endregion
        }
    }
}
