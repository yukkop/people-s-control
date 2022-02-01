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
    public class HCSWriteService : IHCSWriteService
    {
        IHCSRepository _hCSRepository;
        IHCSTypeRepository _hCSTypeRepository;
        IUserRepository _userRepository;
        IActionMetaRepository _actionMetaRepository;
        private readonly IMapper _mapper;

        public HCSWriteService(IHCSRepository hCSRepository, IMapper mapper, IUserRepository userRepository, IHCSTypeRepository hCSTypeRepository, IActionMetaRepository actionMetaRepository )
        {
            _hCSRepository = hCSRepository;
            _hCSTypeRepository = hCSTypeRepository;
            _userRepository = userRepository;
            _actionMetaRepository = actionMetaRepository;
            _mapper = mapper;
        }
        public RequestStatus Create(CreateHCSDTO createEntity, long userId)
        {
            HCS hCS = _mapper.Map<HCS>(createEntity);
            hCS.HCSType = _hCSTypeRepository.Get(createEntity.HCSTypeId);
            hCS.ResponsiblePerson = _userRepository.Get(createEntity.ResponsiblePersonId);
            ActionMeta creation = new ActionMeta()
            {
                UserId = userId,
                Date = DateTime.Now
            };
            creation = _actionMetaRepository.Add(creation);
            _actionMetaRepository.SaveChanges();
            hCS.Creation = creation;

            hCS = _hCSRepository.Add(hCS);
            Exception exception = _hCSRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exception(exception);
            }

            return RequestStatus.Ok();
        }

        public void Delete(long id, long userId)
        {
            HCS hCS = _hCSRepository.Get(id);
            ActionMeta removal = new ActionMeta()
            {
                UserId = userId,
                Date = DateTime.Now
            };
            hCS.Removal = removal;
            hCS.IsVisible = false;
            _hCSRepository.Update(hCS);
            _hCSRepository.SaveChanges();
        }

        public bool Update(UpdateHCSDTO updateEntity, long userId)
        {
            HCS hCS = _mapper.Map<HCS>(updateEntity);
            ActionMeta edit = new ActionMeta()
            {
                UserId = userId,
                Date = DateTime.Now
            };
            hCS.LastEditing = edit;
            edit = _actionMetaRepository.Add(edit);
            _actionMetaRepository.SaveChanges();
            bool status = _hCSRepository.Update(hCS);
            _hCSRepository.SaveChanges();
            return status;
        }
    }
}
