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
    public class DistrictReadService : IDistrictReadService
    {
        IDistrictQuery _districtQuery; 
        private readonly IMapper _mapper;
        public DistrictReadService(IDistrictQuery cityQuery, IMapper mapper)
        {
            _districtQuery = cityQuery;
            _mapper = mapper;
        }

        public GetDistrictDTO Get(long id)
        {
            DistrictDTO entity = _districtQuery.Get(id);
            return _mapper.Map<GetDistrictDTO>(entity);
        }
        public List<GetDistrictDTO> GetAll()
        {
            List<DistrictDTO> entities = _districtQuery.GetAll();
            List<GetDistrictDTO> getEntities = new List<GetDistrictDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetDistrictDTO>(entity));
            }

            return new List<GetDistrictDTO>(getEntities);
        }

        public List<GetDistrictDTO> GetByCityName(string cityName)
        {
            List<DistrictDTO> entities = _districtQuery.GetByCityName(cityName);
            List<GetDistrictDTO> getEntities = new List<GetDistrictDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetDistrictDTO>(entity));
            }

            return getEntities;
        }
    }
}
