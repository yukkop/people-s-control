using AutoMapper;
using DataBase.Models;
using Logic.Helpers;
using Logic.Repositories;
using Logic.WebEntities;
using System;

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

        public RequestStatus Create(CreateReportDTO createEntity, long userId)
        {
            Report entity = _mapper.Map<Report>(createEntity);
            entity.UserId = userId;
            entity.DateCreation = DateTime.Now;

            entity = _reportRepository.Add(entity);

            Exception exception = _reportRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exception(exception);
            }

            return RequestStatus.Ok();
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
