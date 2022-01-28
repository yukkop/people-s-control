using DataBase.Models;
using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportByProblemCategoryWriteService
    {
        public RequestStatus<ReportByProblemCategory> Add(ReportByProblemCategory createEntity);
        public void Delete(ReportByProblemCategory entity);
    }
}
