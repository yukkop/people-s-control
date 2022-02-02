using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class ReportStatusProfile : Profile
    {
        public ReportStatusProfile()
        {
            CreateMap<CreateReportStatusDTO, ReportStatus>();
            CreateMap<UpdateReportStatusDTO, ReportStatus>();
            CreateMap<ReportStatus, GetReportStatusDTO>();
            CreateMap<ReportStatusDTO, GetReportStatusDTO>();
        }
    }
}
