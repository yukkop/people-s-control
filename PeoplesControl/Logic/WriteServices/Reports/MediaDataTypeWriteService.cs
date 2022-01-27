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
    public class MediaDataTypeWriteService : IMediaDataTypeWriteService
    {
        IMediaDataTypeRepository _mediaDataTypeRepository;
        private readonly IMapper _mapper;

        public MediaDataTypeWriteService(IMediaDataTypeRepository mediaDataTypeRepository, IMapper mapper)
        {
            _mediaDataTypeRepository = mediaDataTypeRepository;
            _mapper = mapper;
        }

        public ActionStatus<GetMediaDataTypeDTO> Add(CreateMediaDataTypeDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            MediaDataType entity = _mapper.Map<MediaDataType>(createEntity);
            entity = _mediaDataTypeRepository.Add(entity);


            GetMediaDataTypeDTO getEntity = _mapper.Map<GetMediaDataTypeDTO>(entity);
            _mediaDataTypeRepository.SaveChanges();
            return new ActionStatus<GetMediaDataTypeDTO>(getEntity);
        }

        public bool Update(UpdateMediaDataTypeDTO updateEntity)
        {
            MediaDataType entity = _mapper.Map<MediaDataType>(updateEntity);
            bool status = _mediaDataTypeRepository.Update(entity);
            _mediaDataTypeRepository.SaveChanges();
            return status;
        }
        public void Delete(long id)
        {
            _mediaDataTypeRepository.Delete(id);
            _mediaDataTypeRepository.SaveChanges();
        }
    }
}
