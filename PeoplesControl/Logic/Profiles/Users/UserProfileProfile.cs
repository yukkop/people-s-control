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
            CreateMap<RegistrationDTO, UserProfile>()
                .ForMember(dto => dto.EmailAddress, opt => opt.NullSubstitute(null))
                .ForMember(dto => dto.PhoneNumber, opt => opt.NullSubstitute(null))
                .ForMember(dto => dto.Patronymic, opt => opt.NullSubstitute(null))
                .ForMember(dto => dto.Surname, opt => opt.NullSubstitute(null))
                .ForMember(dto => dto.Name, opt => opt.NullSubstitute(null));
            CreateMap<UserProfile, GetUserProfileDTO>();
            CreateMap<UserProfileDTO, GetUserProfileDTO>();
        }
    }
}
