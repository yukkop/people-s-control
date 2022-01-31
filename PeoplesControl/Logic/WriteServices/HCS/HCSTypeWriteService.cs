using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class HCSTypeWriteService : IHCSTypeWriteService
    {
        IHCSTypeRepository _hCSTypeRepository;
        private readonly IMapper _mapper;

        public HCSTypeWriteService(IHCSTypeRepository hCSTypeRepository, IMapper mapper)
        {
            _hCSTypeRepository = hCSTypeRepository;
            _mapper = mapper;
        }
        public RequestStatus Create(CreateHCSTypeDTO createEntity)
        {
            HCSType hCSType = _mapper.Map<HCSType>(createEntity);
            _hCSTypeRepository.Add(hCSType);
            Exception exception = _hCSTypeRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exception(exception);
            }

            return RequestStatus.Ok();
        }

        public void Delete(long id)
        {
            _hCSTypeRepository.Delete(id);
            _hCSTypeRepository.SaveChanges();
        }

        public bool Update(UpdateHCSTypeDTO updateEntity)
        {
            HCSType entity = _mapper.Map<HCSType>(updateEntity);
            bool status = _hCSTypeRepository.Update(entity);
            _hCSTypeRepository.SaveChanges();
            return status;
        }
    }
}
