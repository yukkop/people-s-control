using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IAvatarQuery
    {
        public AvatarDTO Get(long id);
        public List<AvatarDTO> GetAll();
        public long LastId();
    }
}
