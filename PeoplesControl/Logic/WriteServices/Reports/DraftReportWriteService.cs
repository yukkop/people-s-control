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
    public class DraftReportWriteService : IDraftReportWriteService
    {
        IDraftReportRepository _draftReportRepository;
        IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DraftReportWriteService(IDraftReportRepository draftReportRepository, IMapper mapper, IUserRepository userRepository)
        {
            _draftReportRepository = draftReportRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public RequestStatus Create(CreateDraftReportDTO createEntity, long userId)
        {
            DraftReport draftReport = _mapper.Map<DraftReport>(createEntity);
            draftReport.User = _userRepository.Get(userId);
            draftReport.DateCreation = DateTime.Now;
            draftReport = _draftReportRepository.Add(draftReport);
            Exception exception = _draftReportRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exception(exception);
            }

            return RequestStatus.Ok();
        }

        public void Delete(long id)
        {
            DraftReport draftReport = _draftReportRepository.Get(id);
            draftReport.DateRemoval = DateTime.Now;
            _draftReportRepository.Update(draftReport);
            _draftReportRepository.SaveChanges();
        }

        public bool Update(UpdateDraftReportDTO updateEntity)
        {
            DraftReport entity = _draftReportRepository.Get(updateEntity.Id);
            entity.Id = updateEntity.Id;
            entity.ProblemDescription = updateEntity.ProblemDescription;
            entity.Title = updateEntity.Title;
            entity.Сoordinates = updateEntity.Coordinates;
            entity.DateLastEditing = DateTime.Now;
            bool status = _draftReportRepository.Update(entity);
            _draftReportRepository.SaveChanges();
            return status;
        }
    }
}
