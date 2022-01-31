using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class UserPasswordDTO
    {
        public long UserId { get; set; }
        public long UserProfileId { get; set; }
        public byte[] SaltPassword { get; set; }
        public byte[] SaltValue { get; set; }
    }
}
