using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class ConfirmUserDTO
    {
        public long UserId { get; set; }
        public int ConfirmationCode { get; set; }
    }
}
