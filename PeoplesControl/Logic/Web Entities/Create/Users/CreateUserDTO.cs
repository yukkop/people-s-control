using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateUserDTO
    {
        public long Id { get; set; }
        public long ProfileId { get; set; }
        public string Login { get; set; }
        public byte[] SaltPassword { get; set; }
        public byte[] SaltValue { get; set; }
        public int SMSConfirmationCode { get; set; }
        public int EmailConfirmationCode { get; set; }
        public DateTime DateSMSConfirmation { get; set; }
        public DateTime DateEmailConfirmation { get; set; }
        /*public long RemovalId { get; set; }
        public long LastEditingId { get; set; }
        public long CreationId { get; set; }*/
    }
}
