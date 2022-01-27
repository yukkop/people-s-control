using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IUserProfileReadService
    {
        public ActionStatus<GetUserProfileDTO> Get(long id);
    }
}
