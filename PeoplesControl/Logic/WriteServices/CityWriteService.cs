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
        Mapper _mapper;

        public CityWriteService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<CityProfile>()));
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
            
        //public ActionStatus<GetCityDTO> Get(long id)
        //{
        //    City entity = _cityRepository.Get(id);
        //    GetCityDTO getEntity = _mapper.Map<GetCityDTO>(entity);
        //    return new ActionStatus<GetCityDTO>(getEntity);
        //}

        //public ActionStatus<List<GetCityDTO>> Get()
        //{
        //    List<GetCityDTO> getEntities = new List<GetCityDTO>();
        //    List<City> entities = _cityRepository.GetAll();

        //    entities.ForEach(entity => 
        //        {
        //            getEntities.Add(_mapper.Map<GetCityDTO>(entity));
        //        }
        //    );

        //    return new ActionStatus<List<GetCityDTO>>(getEntities);
        //}
    }
}
