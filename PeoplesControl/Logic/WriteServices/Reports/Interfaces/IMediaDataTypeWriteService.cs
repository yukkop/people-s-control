using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IMediaDataTypeWriteService
    {
        public RequestStatus<GetMediaDataTypeDTO> Add(CreateMediaDataTypeDTO createEntity);
        public bool Update(UpdateMediaDataTypeDTO updateEntity);
        public void Delete(long id);
    }
}
