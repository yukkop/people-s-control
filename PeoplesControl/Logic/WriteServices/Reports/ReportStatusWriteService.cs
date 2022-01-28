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
    public class ReportStatusWriteService : IReportStatusWriteService
    {
        IReportStatusRepository _reportStatusRepository;
        private readonly IMapper _mapper;

        public ReportStatusWriteService(IReportStatusRepository reportStatusRepository, IMapper mapper)
        {
            _reportStatusRepository = reportStatusRepository;
            _mapper = mapper;
        }

        public RequestStatus<GetReportStatusDTO> Add(CreateReportStatusDTO createEntity)
        {
            // проверка на уникальность в параметрах полей
            ReportStatus entity = _mapper.Map<ReportStatus>(createEntity);
            entity = _reportStatusRepository.Add(entity);


            GetReportStatusDTO getEntity = _mapper.Map<GetReportStatusDTO>(entity);
            _reportStatusRepository.SaveChanges();
            return new RequestStatus<GetReportStatusDTO>(getEntity);
        }

        public bool Update(UpdateReportStatusDTO updateEntity)
        {
            ReportStatus entity = _mapper.Map<ReportStatus>(updateEntity);
            bool status = _reportStatusRepository.Update(entity);
            _reportStatusRepository.SaveChanges();
            return status;
        }
        public void Delete(long id)
        {
            _reportStatusRepository.Delete(id);
            _reportStatusRepository.SaveChanges();
        }
    }
}
