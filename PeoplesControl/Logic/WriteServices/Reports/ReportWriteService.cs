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
    public class ReportWriteService : IReportWriteService
    {
        IReportRepository _reportRepository;
        IUserRepository _userRepository;
        IReportStatusRepository _reportStatusRepository;
        private readonly IMapper _mapper;

        public ReportWriteService(IReportRepository reportRepository, IMapper mapper, IUserRepository userRepository, IReportStatusRepository reportStatusRepository)
        {
            _reportRepository = reportRepository;
            _userRepository = userRepository;
            _reportStatusRepository = reportStatusRepository;
            _mapper = mapper;
        }

        public RequestStatus<GetReportDTO> Add(CreateReportDTO createEntity)
        {
            Report entity = _mapper.Map<Report>(createEntity);
            entity.User = _userRepository.Get(entity.UserId);
            entity.Status = _reportStatusRepository.Get(entity.StatusId);
            entity.DateCreation = DateTime.Now;
            entity.RelationReportId = null;
           // entity.RelationReport = entity;
            entity = _reportRepository.Add(entity);


            GetReportDTO getEntity = _mapper.Map<GetReportDTO>(entity);
            _reportRepository.SaveChanges();
            return new RequestStatus<GetReportDTO>(getEntity);
        }

        public bool Update(UpdateReportDTO updateEntity)
        {
            Report entity = _mapper.Map<Report>(updateEntity);
            entity.DateLastEditing = DateTime.Now;
            bool status = _reportRepository.Update(entity);
            _reportRepository.SaveChanges();
            return status;
        }
        public void Delete(long id)
        {
            Report report = _reportRepository.Get(id);
            report.DateRemoval = DateTime.Now;
            report.IsDeleted = true;
            _reportRepository.Update(report);
            _reportRepository.SaveChanges();
        }
    }
}
