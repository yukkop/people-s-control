using AutoMapper;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class AvatarReadService : IAvatarReadService
    {
        IAvatarQuery _cityQuery;
        Mapper _mapper;
        public AvatarReadService(IAvatarQuery cityQuery)
        {
            _cityQuery = cityQuery;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AvatarProfile>()));
        }

        public ActionStatus<GetAvatarDTO> Get(long id)
        {
            AvatarDTO entity = _cityQuery.Get(id);
            return new ActionStatus<GetAvatarDTO>(_mapper.Map<GetAvatarDTO>(entity));
        }
        public ActionStatus<List<GetAvatarDTO>> GetAll()
        {
            List<AvatarDTO> entities = _cityQuery.GetAll();
            List<GetAvatarDTO> getEntities = new List<GetAvatarDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetAvatarDTO>(entity));
            }

            return new ActionStatus<List<GetAvatarDTO>>(getEntities);
        }
    }
}

