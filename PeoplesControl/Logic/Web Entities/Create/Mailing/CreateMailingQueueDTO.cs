using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateMailingQueueDTO
    {
        public long Id { get; set; }
        public long MailingStatusId { get; set; }
        public long UserId { get; set; }

    }
}
