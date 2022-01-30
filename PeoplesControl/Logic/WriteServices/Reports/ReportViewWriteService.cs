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

        public RequestStatus Add(long reportId, long userId)
        {
            ReportView entity = new ReportView();
            entity.ReportId = reportId;
            entity.UserId = userId;

            _reportViewRepository.Add(entity);
            Exception exception = _reportViewRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            return RequestStatus.Ok();
        }
    }
}
