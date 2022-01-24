using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IMediaDataTypeReadService
    {
        public ActionStatus<GetMediaDataTypeDTO> Get(long id);
        public ActionStatus<List<GetMediaDataTypeDTO>> GetAll();
    }
}
