using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UserDTO
    {
        public long Id { get; set; }
        public long UserProfileId { get; set; }
        public string Login { get; set; }
        public int? SMSConfirmationCode { get; set; }
        public int? EmailConfirmationCode { get; set; }
        //public DateTime? DateSMSConfirmation { get; set; }
        //public DateTime? DateEmailConfirmation { get; set; }
    }
}
