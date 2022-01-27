using AutoMapper;
using DataBase.Models;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Profiles
{
    public class RoleProfile: Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDTO, GetRoleDTO>();
            CreateMap<Role, GetRoleDTO>();
            CreateMap<CreateRoleDTO, Role>();
            CreateMap<UpdateRoleDTO, Role>();
        }
    }
}
