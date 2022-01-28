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
        IAvatarQuery _avatarQuery; 
        private readonly IMapper _mapper;
        public AvatarReadService(IAvatarQuery avatarQuery, IMapper mapper)
        {
            _avatarQuery = avatarQuery;
            _mapper = mapper;
        }

        public RequestStatus<GetAvatarDTO> Get(long id)
        {
            AvatarDTO entity = _avatarQuery.Get(id);
            return new RequestStatus<GetAvatarDTO>(_mapper.Map<GetAvatarDTO>(entity));
        }
        public RequestStatus<List<GetAvatarDTO>> GetAll()
        {
            List<AvatarDTO> entities = _avatarQuery.GetAll();
            List<GetAvatarDTO> getEntities = new List<GetAvatarDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetAvatarDTO>(entity));
            }

            return new RequestStatus<List<GetAvatarDTO>>(getEntities);
        }
    }
}

