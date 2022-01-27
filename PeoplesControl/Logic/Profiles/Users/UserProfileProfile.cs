using AutoMapper;
using DataBase.Models;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<RegistrationDTO, User>();
            CreateMap<RegistrationDTO, UserProfile>();
            CreateMap<UserProfile, GetUserProfileDTO>();
            CreateMap<UserProfileDTO, GetUserProfileDTO>();
        }
    }
}
