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

        public ActionStatus<ReportView> Add(ReportView createEntity)
        {
            ActionStatus<ReportView> actionStatus =  new ActionStatus<ReportView>(_reportViewRepository.Add(createEntity));
            _reportViewRepository.SaveChanges();
            return actionStatus;
        }
    }
}
