using AutoMapper;
using DataBase.Models;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class DistrictProfile : Profile
    {
        public DistrictProfile(DistrictRepository districtRepository)
        { 
            CreateMap<CreateDistrictDTO, District>();
            CreateMap<CreateDistrictDTO, District>().ForMember("City", opt=>opt.MapFrom(c=>districtRepository.Get(c.CityId)));
            CreateMap<UpdateDistrictDTO, District>();
            CreateMap<District, GetDistrictDTO>();
            CreateMap<DistrictDTO, GetDistrictDTO>().ForMember("CityName", opt => opt.MapFrom(c => c.City.Name));
        }
    }
}
