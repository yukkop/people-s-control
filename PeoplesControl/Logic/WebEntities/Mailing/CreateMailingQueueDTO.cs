using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateMailingQueueDTO
    {
        public long Id { get; set; }
        public long MailingStatusId { get; set; }
        public long UserId { get; set; }

    }
}
