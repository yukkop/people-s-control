using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Logic.Queries;
using Logic.WebEntities;
using AutoMapper;
using Logic.Profiles;

namespace Logic.ReadServices
{
    public class CityReadService: ICityReadService
    {
        ICityQuery _cityQuery;
        private readonly IMapper _mapper;
        public CityReadService(ICityQuery cityQuery, IMapper mapper)
        {
            _cityQuery = cityQuery;
            _mapper = mapper;
        }

        public RequestStatus<GetCityDTO >Get(long id)
        {
            CityDTO entity = _cityQuery.Get(id);
            return new RequestStatus<GetCityDTO>( _mapper.Map<GetCityDTO>(entity));
        }
        public RequestStatus< List<GetCityDTO> >GetAll()
        {
            List<CityDTO> entities = _cityQuery.GetAll();
            List<GetCityDTO> getEntities = new List<GetCityDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetCityDTO>(entity));
            }

            return new RequestStatus<List<GetCityDTO>>(getEntities);
        }
    }
}
