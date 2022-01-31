using AutoMapper;
using DataBase.Models;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class HCSTypeProfile : Profile
    {
        public HCSTypeProfile()
        {
            CreateMap<CreateHCSTypeDTO, HCSType>();
            CreateMap<UpdateHCSTypeDTO, HCSType>();
            CreateMap<HCSType, GetHCSTypeDTO>();
            CreateMap<HCSTypeDTO, GetHCSTypeDTO>();
        }
    }
}
