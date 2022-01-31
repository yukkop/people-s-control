using DataBase.Models;
using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportByProblemCategoryWriteService
    {
        public RequestStatus Add(long reportId, long categoryId);
        public RequestStatus Delete(long id, long categoryI);
    }
}
