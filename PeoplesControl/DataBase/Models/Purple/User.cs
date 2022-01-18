using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class User
    {
        public long Id { get; set; }
        public Profile Profile { get; set; }
        public string Login { get; set; }
        public byte[] SaltPassword { get; set; }
        public byte[] SaltValue { get; set; }
        public int SMSConfirmationCode { get; set; }
        public int EmailConfirmationCode { get; set; }
        public DateTime DateSMSConfirmation { get; set; }
        public DateTime DateEmailConfirmation { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }

    }
}
