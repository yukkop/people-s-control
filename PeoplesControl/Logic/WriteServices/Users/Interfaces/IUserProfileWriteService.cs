using Logic.Helpers;
using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WriteServices
{
    public interface IUserProfileWriteService
    {
        public RequestStatus RegistrationByEmail(RegistrationByEmailDTO registrationEntity);
        public bool UpdatePrivateInfo(UpdateUserProfileDTO updateEntity);
        public RequestStatus ConfirmEmail(long userID, int confirmationCode);
        public RequestStatus ResendConfirmationCodeEmail(long userId);
        public void Delete(long id);
    }
}
