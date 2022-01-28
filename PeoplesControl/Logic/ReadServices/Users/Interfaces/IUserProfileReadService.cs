using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.ReadServices
{
    public interface IUserProfileReadService
    {
        public RequestStatus<GetUserProfileDTO> Get(long id);
    }
}
