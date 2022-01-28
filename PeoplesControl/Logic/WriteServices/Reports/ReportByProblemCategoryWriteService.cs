using DataBase.Models;
using Logic.Helpers;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public class ReportByProblemCategoryWriteService : IReportByProblemCategoryWriteService
    {
        IReportByProblemCategoryRepository _reportByProblemCategoryRepository;

        public ReportByProblemCategoryWriteService(IReportByProblemCategoryRepository reportByProblemCategoryRepository)
        {
            _reportByProblemCategoryRepository = reportByProblemCategoryRepository;
        }

        public RequestStatus<ReportByProblemCategory> Add(ReportByProblemCategory createEntity)
        {
            RequestStatus<ReportByProblemCategory> actionStatus = new RequestStatus<ReportByProblemCategory>(_reportByProblemCategoryRepository.Add(createEntity));
            _reportByProblemCategoryRepository.SaveChanges();
            return actionStatus;
        }

        public void Delete(ReportByProblemCategory entity)
        {
            _reportByProblemCategoryRepository.Delete(entity);
            _reportByProblemCategoryRepository.SaveChanges();
        }
    }
}
