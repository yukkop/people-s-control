using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<CreateReportDTO, Report>().ValueTransformers.Add<long?>(val => val == 0 ? null : val);
            CreateMap<UpdateReportDTO, Report>();
            CreateMap<Report, GetReportDTO>();
            CreateMap<ReportDTO, GetReportDTO>();
        }
    }
}
