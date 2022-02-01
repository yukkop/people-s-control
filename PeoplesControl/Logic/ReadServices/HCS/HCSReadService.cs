using AutoMapper;
using Logic.Helpers;
using Logic.Queries;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public class HCSReadService : IHCSReadService
    {
        IHCSQuery _hCSQuery;
        private readonly IMapper _mapper;
        public HCSReadService(IHCSQuery hCSQuery, IMapper mapper)
        {
            _hCSQuery = hCSQuery;
            _mapper = mapper;
        }

        public RequestStatus<List<GetHCSDTO>> GetAll()
        {
            List<HCSDTO> entities = _hCSQuery.GetAll();
            List<GetHCSDTO> getEntities = new List<GetHCSDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetHCSDTO>(entity));
            }

            return new RequestStatus<List<GetHCSDTO>>(getEntities);
        }

        public RequestStatus<GetHCSDTO> Get(long id)
        {
            return new RequestStatus<GetHCSDTO>(_mapper.Map<GetHCSDTO>(_hCSQuery.Get(id)));
        }
    }
}
