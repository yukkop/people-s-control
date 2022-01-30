using DataBase.Models;
using Logic.Helpers;
using Logic.Queries;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class ReportByProblemCategoryWriteService : IReportByProblemCategoryWriteService
    {
        IReportByProblemCategoryRepository _reportByProblemCategoryRepository;
        IReportByProblemCategoryQuery _reportByProblemCategoryQuery;

        public ReportByProblemCategoryWriteService(
            IReportByProblemCategoryRepository reportByProblemCategoryRepository,
            IReportByProblemCategoryQuery reportByProblemCategoryQuery
            )
        {
            _reportByProblemCategoryRepository = reportByProblemCategoryRepository;
            _reportByProblemCategoryQuery = reportByProblemCategoryQuery;
        }

        public RequestStatus Add(long reportId, long categoryId)
        {
            ReportByProblemCategory entity = new ReportByProblemCategory();
            entity.ReportId = reportId;
            entity.ProblemCategoryId = categoryId;

            _reportByProblemCategoryRepository.Add(entity);
            Exception exception = _reportByProblemCategoryRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            return RequestStatus.Ok();
        }

        public RequestStatus Delete(long reportId, long categoryId)
        {
            long? reportByProblemCategoryId = _reportByProblemCategoryQuery.FindInReport(reportId, categoryId);
            if (reportByProblemCategoryId == null)
            {
                return new RequestStatus(RequestStatus.Statuses.BadParams, "Эта заявкая не содержит такую категорию.");
            }

            ReportByProblemCategory entity = _reportByProblemCategoryRepository.Get((long)reportByProblemCategoryId);
            _reportByProblemCategoryRepository.Delete(entity);
            Exception exception =  _reportByProblemCategoryRepository.SaveChanges();
            if (exception != null)
            {
                return RequestStatus.Exeption(exception);
            }

            return RequestStatus.Ok();
        }
    }
}
