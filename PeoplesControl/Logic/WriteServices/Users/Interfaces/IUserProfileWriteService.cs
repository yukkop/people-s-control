using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IUserProfileWriteService
    {
        public GetUserProfileDTO Registration(RegistrationDTO createEntity);
        public bool UpdatePrivateInfo(UpdateUserProfileDTO updateEntity);
        public void Delete(long id);
    }
}
