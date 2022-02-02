using DataBase.Models;
using Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IReportViewWriteService
    {
        public RequestStatus Add(long id, long userId);
    }
}
