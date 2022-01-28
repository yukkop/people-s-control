using DataBase.Models;
using Logic.Helpers;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class ReportViewWriteService : IReportViewWriteService
    {
        IReportViewRepository _reportViewRepository;

        public ReportViewWriteService(IReportViewRepository reportViewRepository)
        {
            _reportViewRepository = reportViewRepository;
        }

        public RequestStatus<ReportView> Add(ReportView createEntity)
        {
            RequestStatus<ReportView> actionStatus =  new RequestStatus<ReportView>(_reportViewRepository.Add(createEntity));
            _reportViewRepository.SaveChanges();
            return actionStatus;
        }
    }
}
