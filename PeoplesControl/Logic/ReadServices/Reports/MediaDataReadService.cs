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
    public class MediaDataTypeReadService : IMediaDataTypeReadService
    {
        IMediaDataTypeQuery _mediaDataTypeQuery;
        private readonly IMapper _mapper;
        public MediaDataTypeReadService(IMediaDataTypeQuery mediaDataTypeQuery, IMapper mapper)
        {
            _mediaDataTypeQuery = mediaDataTypeQuery;
            _mapper = mapper;
        }

        public RequestStatus<GetMediaDataTypeDTO> Get(long id)
        {
            MediaDataTypeDTO entity = _mediaDataTypeQuery.Get(id);
            return new RequestStatus<GetMediaDataTypeDTO>(_mapper.Map<GetMediaDataTypeDTO>(entity));
        }
        public RequestStatus<List<GetMediaDataTypeDTO>> GetAll()
        {
            List<MediaDataTypeDTO> entities = _mediaDataTypeQuery.GetAll();
            List<GetMediaDataTypeDTO> getEntities = new List<GetMediaDataTypeDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetMediaDataTypeDTO>(entity));
            }

            return new RequestStatus<List<GetMediaDataTypeDTO>>(getEntities);
        }
    }
}

