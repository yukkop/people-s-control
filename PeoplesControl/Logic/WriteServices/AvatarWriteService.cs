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
    public class AvatarWriteService : IAvatarWriteService
    {
        IAvatarRepository _cityRepository;
        Mapper _mapper;

        public AvatarWriteService(IAvatarRepository cityRepository)
        {
            _cityRepository = cityRepository;
            _mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<AvatarProfile>()));
        }

        public ActionStatus<GetAvatarDTO> Add(CreateAvatarDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            Avatar entity = _mapper.Map<Avatar>(createEntity);
            entity = _cityRepository.Add(entity);


            GetAvatarDTO getEntity = _mapper.Map<GetAvatarDTO>(entity);
            _cityRepository.SaveChanges();
            return new ActionStatus<GetAvatarDTO>(getEntity);
        }

        public bool Update(UpdateAvatarDTO updateEntity)
        {
            Avatar entity = _mapper.Map<Avatar>(updateEntity);
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
