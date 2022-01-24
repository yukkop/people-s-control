using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class AvatarProfile : Profile
    {
        public AvatarProfile()
        {
            CreateMap<CreateAvatarDTO, Avatar>();
            CreateMap<UpdateAvatarDTO, Avatar>();
            CreateMap<Avatar, GetAvatarDTO>();
            CreateMap<AvatarDTO, GetAvatarDTO>();
        }
    }
}
