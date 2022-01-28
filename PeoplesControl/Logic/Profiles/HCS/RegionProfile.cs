using AutoMapper;
using DataBase.Models;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class RegionProfile: Profile
    {
        public RegionProfile()
        {
            CreateMap<CreateRegionDTO, Region>()
                .ForMember(dto => dto.IsRegionSupported, opt => opt.NullSubstitute(false))
                .ForMember(dto => dto.CityId, opt => opt.NullSubstitute(1));
        }
    }
}
