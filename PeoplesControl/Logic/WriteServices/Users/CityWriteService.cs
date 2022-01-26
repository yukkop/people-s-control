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

        public ActionStatus<GetCityDTO> Add(CreateCityDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            City entity = _mapper.Map<City>(createEntity);
            entity = _cityRepository.Add(entity);
            GetCityDTO getEntity = _mapper.Map<GetCityDTO>(entity);
            _cityRepository.SaveChanges();
            return new ActionStatus<GetCityDTO>(getEntity);
        }

        public bool Update(UpdateCityDTO updateEntity)
        {
            City entity = _mapper.Map<City>(updateEntity);
            bool status = _cityRepository.Update(entity);
            _cityRepository.SaveChanges();
            return status;
        }

        public void Delete(long id)
        {
            _cityRepository.Delete(id);
            _cityRepository.SaveChanges();
        }
    }
}
