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
        public DistrictProfile()
        { 
            CreateMap<CreateDistrictDTO, District>();
            CreateMap<UpdateDistrictDTO, District>();
            CreateMap<District, GetDistrictDTO>();
            CreateMap<DistrictDTO, GetDistrictDTO>();
        }
    }
}
