using System;
using System.Collections.Generic;
using System.Text;
using Logic.Repositories;
using AutoMapper;
using Logic.WebEntities;
using Logic.Helpers;
using DataBase.Models;

namespace Logic.WriteServices
{
    public class RoleWriteService: IRoleWriteService
    {
        IRoleRepository _roleRepository;
        IActionMetaRepository _actionMetaRepository;
        private readonly IMapper _mapper;

        public RoleWriteService(IRoleRepository roleRepository, IActionMetaRepository actionMetaRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _actionMetaRepository = actionMetaRepository;
            _mapper = mapper;
        }

        public RequestStatus<GetRoleDTO> Add(CreateRoleDTO createEntity)
        {
            ActionMeta createAction = new ActionMeta();
            createAction.UserId = createEntity.UserId;
            createAction.Date = DateTime.Now;

            Role entity = _mapper.Map<Role>(createEntity);

            createAction = _actionMetaRepository.Add(createAction);

            entity.Creation = createAction;
            entity = _roleRepository.Add(entity);

            _roleRepository.SaveChanges();

            return new RequestStatus<GetRoleDTO>(_mapper.Map<GetRoleDTO>(entity));
            //_roleRepository.Add()
        }

        public bool Update(UpdateRoleDTO updateEntity)
        {
            ActionMeta createEdition = new ActionMeta();
            //createEdition.UserId = updateEntity.UserId;
            createEdition.Date = DateTime.Now;

            Role entity = _mapper.Map<Role>(updateEntity);
            return false;
        }
    }
}
