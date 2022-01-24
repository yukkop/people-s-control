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
        IAvatarRepository _avatarRepository; 
        private readonly IMapper _mapper;

        public AvatarWriteService(IAvatarRepository avatarRepository, IMapper mapper)
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
        }

        public ActionStatus<GetAvatarDTO> Add(CreateAvatarDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            Avatar entity = _mapper.Map<Avatar>(createEntity);
            entity = _avatarRepository.Add(entity);


            GetAvatarDTO getEntity = _mapper.Map<GetAvatarDTO>(entity);
            _avatarRepository.SaveChanges();
            return new ActionStatus<GetAvatarDTO>(getEntity);
        }

        public bool Update(UpdateAvatarDTO updateEntity)
        {
            Avatar entity = _mapper.Map<Avatar>(updateEntity);
            bool status = _avatarRepository.Update(entity);
            _avatarRepository.SaveChanges();
            return status;
        }
        public void Delete(long id)
        {
            _avatarRepository.Delete(id);
            _avatarRepository.SaveChanges();
        }
    }
}
