using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    class MailingQueue
    {
        public long Id { get; set; }
        public MailingStatus MailingStatus { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
