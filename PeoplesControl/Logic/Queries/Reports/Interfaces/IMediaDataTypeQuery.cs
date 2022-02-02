using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IMediaDataTypeQuery
    {
        public MediaDataTypeDTO Get(long id);
        public List<MediaDataTypeDTO> GetAll();
    }
}
