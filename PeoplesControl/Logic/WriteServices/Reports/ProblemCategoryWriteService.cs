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
    public class ProblemCategoryWriteService : IProblemCategoryWriteService
    {
        IProblemCategoryRepository _problemCategoryRepository;
        IActionMetaRepository _actionMetaRepository;
        IAvatarWriteService _avatarWriteService;
        private readonly IMapper _mapper;

        public ProblemCategoryWriteService(IProblemCategoryRepository problemCategoryRepository, IActionMetaRepository actionMetaRepository, IAvatarWriteService avatarWriteService, IMapper mapper)
        {
            _problemCategoryRepository = problemCategoryRepository;
            _actionMetaRepository = actionMetaRepository;
            _avatarWriteService = avatarWriteService;
            _mapper = mapper;
        }

        public RequestStatus<GetProblemCategoryDTO> Add(CreateProblemCategoryDTO createEntity)
        {
            ProblemCategory entity = _mapper.Map<ProblemCategory>(createEntity);
            
            ActionMeta creation = new ActionMeta();
            creation.UserId = createEntity.UserId;
            creation.Date = DateTime.Now;
            creation = _actionMetaRepository.Add(creation);
            _actionMetaRepository.SaveChanges();
            entity.Creation = creation;
            entity.IsActive = true;
            entity.IsVisible = true;

            //_avatarWriteService.Add()     //FIXME аватарка проблемной категории

            entity = _problemCategoryRepository.Add(entity);
            GetProblemCategoryDTO getEntity = _mapper.Map<GetProblemCategoryDTO>(entity);
            _problemCategoryRepository.SaveChanges();
            return new RequestStatus<GetProblemCategoryDTO>(getEntity);
        }

        public bool Update(UpdateProblemCategoryDTO updateEntity)
        {
            ProblemCategory entity = _mapper.Map<ProblemCategory>(updateEntity);

            ActionMeta update = new ActionMeta();
            update.UserId = updateEntity.UserId;
            update.Date = DateTime.Now;

            update = _actionMetaRepository.Add(update);
            _actionMetaRepository.SaveChanges();
            entity.LastEditing = update;


            bool status = _problemCategoryRepository.Update(entity);
            _problemCategoryRepository.SaveChanges();
            return status;
        }
        public void Delete(long id, long userId)
        {
            ProblemCategory problemCategory = _problemCategoryRepository.Get(id);

            ActionMeta delete = new ActionMeta();
            delete.UserId = delete.UserId;
            delete.Date = DateTime.Now;
            delete = _actionMetaRepository.Add(delete);
            problemCategory.Removal = delete;
            problemCategory.IsActive = false;
            problemCategory.IsVisible = false;
            _problemCategoryRepository.Update(problemCategory);
            _problemCategoryRepository.SaveChanges();
        }
    }
}
