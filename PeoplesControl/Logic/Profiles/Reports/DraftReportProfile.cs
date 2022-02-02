using AutoMapper;
using Logic.WebEntities;
using DataBase.Models;

namespace Logic.Profiles
{
    public class DraftReportProfile : Profile
    {
        public DraftReportProfile()
        {
            CreateMap<CreateDraftReportDTO, DraftReport>().ValueTransformers.Add<long?>(val => val == 0 ? null : val);
            CreateMap<UpdateDraftReportDTO, DraftReport>();
            CreateMap<DraftReport, GetDraftReportDTO>();
            CreateMap<DraftReportDTO, GetDraftReportDTO>();
        }
    }
}
