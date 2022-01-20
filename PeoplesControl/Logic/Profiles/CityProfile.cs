using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class CityProfile: Profile
    {
        public CityProfile()
        {
            CreateMap<CreateCityDTO, City>();
            CreateMap<City, GetCityDTO>();
            CreateMap<CityDTO, GetCityDTO>();
        }
    }
}
