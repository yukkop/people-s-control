using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic.Repositories;
using Logic.WebEntities;
using Logic.Helpers;
using AutoMapper;
using DataBase.Models;
using Logic.Profiles;

namespace Logic.WriteServices
{
    public class CityWriteService : ICityWriteService
    {
        ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityWriteService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public RequestStatus Add(CreateCityDTO createEntity)
        {
            City entity = _mapper.Map<City>(createEntity);
            _cityRepository.Add(entity);

            Exception exception = _cityRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            return RequestStatus.Ok();
        }

        public bool Update(UpdateCityDTO updateEntity)
        {
            City entity = _mapper.Map<City>(updateEntity);
            bool status = _cityRepository.Update(entity);
            _cityRepository.SaveChanges();
            return status;
        }

        public RequestStatus Delete(long id)
        {
            Exception exception = _cityRepository.Delete(id);
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }
            _cityRepository.SaveChanges();
            return RequestStatus.Ok();
        }
    }
}
