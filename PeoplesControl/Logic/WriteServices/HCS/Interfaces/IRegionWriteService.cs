using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IRegionWriteService
    {
        public bool MakeItSupported(long id);
        public bool MakeItUnsupported(long id);
    }
}
