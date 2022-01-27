﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Logic.Helpers;
using Logic.Queries;
using Logic.WebEntities;

namespace Logic.ReadServices
{
    public class RoleReadService: IRoleReadService
    {
        IRoleQuery _roleQuery;
        IMapper _mapper;
        public RoleReadService(IRoleQuery roleQuery, IMapper mapper)
        {
            _roleQuery = roleQuery;
            _mapper = mapper;
        }

        public ActionStatus<GetRoleDTO> Get(long id)
        {
            RoleDTO entity = _roleQuery.Get(id);
            GetRoleDTO getEntity = _mapper.Map<GetRoleDTO>(entity);
            return new ActionStatus<GetRoleDTO>(getEntity);
        }

        public ActionStatus<List<GetRoleDTO>> GetAll()
        {
            List<RoleDTO> entities = _roleQuery.GetAll();
            List<GetRoleDTO> getEntities = new List<GetRoleDTO>();

            foreach (var entity in entities)
            {
                getEntities.Add(_mapper.Map<GetRoleDTO>(entity));
            }

            return new ActionStatus<List<GetRoleDTO>>(getEntities);
        }
    }
}
