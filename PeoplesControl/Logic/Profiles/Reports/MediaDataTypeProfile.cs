using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class MediaDataTypeProfile : Profile
    {
        public MediaDataTypeProfile()
        {
            CreateMap<CreateMediaDataTypeDTO, MediaDataType>();
            CreateMap<UpdateMediaDataTypeDTO, MediaDataType>();
            CreateMap<MediaDataType, GetMediaDataTypeDTO>();
            CreateMap<MediaDataTypeDTO, GetMediaDataTypeDTO>();
        }
    }
}
