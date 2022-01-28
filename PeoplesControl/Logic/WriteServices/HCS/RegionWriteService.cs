using AutoMapper;
using DataBase.Models;
using Logic.Repositories;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class RegionWriteService : IRegionWriteService
    {
        IRegionRepository _regionRepository;
        IActionMetaRepository _actionMetaRepository;
        IMapper _mapper;
        public RegionWriteService(IRegionRepository regionRepository, IMapper mapper, IActionMetaRepository actionMetaRepository)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _actionMetaRepository = actionMetaRepository;
    }

        public bool MakeItSupported(long id)
        {
            Region entity = _regionRepository.Get(id);
            if (entity.IsRegionSupported != true)
            {
                entity.IsRegionSupported = true;
                _regionRepository.Update(entity);
                _regionRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public bool MakeItUnsupported(long id)
        {
            Region entity = _regionRepository.Get(id);
            if (entity.IsRegionSupported != false)
            {
                entity.IsRegionSupported = false;
                _regionRepository.Update(entity);
                _regionRepository.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Add(CreateRegionDTO createEntity, long userId)
        {
            Region entity = _mapper.Map<Region>(createEntity);

            ActionMeta creation = new ActionMeta();
            creation.Date = DateTime.Now;
            _actionMetaRepository.Add(creation);
        }
    }
}
