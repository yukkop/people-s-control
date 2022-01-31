using AutoMapper;
using Logic.Helpers;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class HCSTypeReadService : IHCSTypeReadService
    {
        IHCSTypeQuery _hCSTypeQuery; 
        private readonly IMapper _mapper;
        public HCSTypeReadService(IHCSTypeQuery hCSTypeQuery, IMapper mapper)
        {
            _hCSTypeQuery = hCSTypeQuery;
            _mapper = mapper;
        }

        public RequestStatus<List<GetHCSTypeDTO>> GetAll()
        {
            List<HCSTypeDTO> entities = _hCSTypeQuery.GetAll();
            List<GetHCSTypeDTO> getEntities = new List<GetHCSTypeDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetHCSTypeDTO>(entity));
            }

            return new RequestStatus<List<GetHCSTypeDTO>>(getEntities);
        }

        public RequestStatus<GetHCSTypeDTO> Get(long id)
        {
            return new RequestStatus<GetHCSTypeDTO>( _mapper.Map<GetHCSTypeDTO>(_hCSTypeQuery.Get(id)));
        }
    }
}
