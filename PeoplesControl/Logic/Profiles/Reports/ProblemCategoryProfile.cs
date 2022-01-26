using AutoMapper;
using DataBase.Models;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class ProblemCategoryProfile : Profile
    {
        public ProblemCategoryProfile()
        {
            CreateMap<CreateProblemCategoryDTO, ProblemCategory>().ValueTransformers.Add<long?>(val => val == 0 ? null : val); ;
            CreateMap<UpdateProblemCategoryDTO, ProblemCategory>().ValueTransformers.Add<long?>(val => val == 0 ? null : val); ;
            CreateMap<ProblemCategory, GetProblemCategoryDTO>();
            CreateMap<ProblemCategoryDTO, GetProblemCategoryDTO>();
        }
    }
}
