using AutoMapper;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;

namespace Logic.Profiles
{
    public class HCSProfile : Profile
    {
        public HCSProfile()
        {
            CreateMap<CreateHCSDTO, HCS>();
            CreateMap<UpdateHCSDTO, HCS>();
            CreateMap<HCS, GetHCSDTO>();
            CreateMap<HCSDTO, GetHCSDTO>();
        }
    }
}
