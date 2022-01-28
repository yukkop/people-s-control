using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IUserProfileWriteService
    {
        public bool RegistrationByEmail(RegistrationDTO registrationEntity);
        public bool UpdatePrivateInfo(UpdateUserProfileDTO updateEntity);
        public bool ConfirmEmail(long userID, int confirmationCode);
        public void Delete(long id);
    }
}
