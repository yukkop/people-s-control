using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IRegionWriteService
    {
        public bool MakeItSupported(long id, long userId);
        public bool MakeItUnsupported(long id, long userId);
        public bool Add(CreateRegionDTO createEntity, long userId);
    }
}
