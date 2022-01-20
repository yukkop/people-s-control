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
        IDistrictQuery _cityQuery;
        Mapper _mapper;
        public DistrictReadService(IDistrictQuery cityQuery)
        {
            _cityQuery = cityQuery;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DistrictProfile>()));
        }

        public ActionStatus<GetDistrictDTO> Get(long id)
        {
            DistrictDTO entity = _cityQuery.Get(id);
            return new ActionStatus<GetDistrictDTO>(_mapper.Map<GetDistrictDTO>(entity));
        }
        public ActionStatus<List<GetDistrictDTO>> GetAll()
        {
            List<DistrictDTO> entities = _cityQuery.GetAll();
            List<GetDistrictDTO> getEntities = new List<GetDistrictDTO>();

            foreach (var entity in entities)
            {
                GetDistrictDTO tmp = _mapper.Map<GetDistrictDTO>(entity);
                getEntities.Add(_mapper.Map<GetDistrictDTO>(entity));
            }

            return new ActionStatus<List<GetDistrictDTO>>(getEntities);
        }

        public ActionStatus<List<GetDistrictDTO>> GetByCityName(string cityName)
        {
            List<DistrictDTO> entities = _cityQuery.GetByCityName(cityName);
            List<GetDistrictDTO> getEntities = new List<GetDistrictDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetDistrictDTO>(entity));
            }

            return new ActionStatus<List<GetDistrictDTO>>(getEntities);
        }
    }
}
