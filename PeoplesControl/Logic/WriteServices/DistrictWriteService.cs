using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Profiles;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class DistrictWriteService : IDistrictWriteService
    {
        IDistrictRepository _districtRepository;
        Mapper _mapper;

        public DistrictWriteService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<DistrictProfile>()));
        }

        public ActionStatus<GetDistrictDTO> Add(CreateDistrictDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            District entity = _mapper.Map<District>(createEntity);
            entity = _districtRepository.Add(entity);


            GetDistrictDTO getEntity = _mapper.Map<GetDistrictDTO>(entity);
            _districtRepository.SaveChanges();
            return new ActionStatus<GetDistrictDTO>(getEntity);
        }

        public bool Update(UpdateDistrictDTO updateEntity)
        {
            District entity = _mapper.Map<District>(updateEntity);
            bool status = _districtRepository.Update(entity);
            _districtRepository.SaveChanges();
            return status;
        }
        public void Delete(long id)
        {
            _districtRepository.Delete(id);
            _districtRepository.SaveChanges();
        }
    }
}
