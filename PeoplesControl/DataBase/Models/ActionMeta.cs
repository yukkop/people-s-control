using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class ActionMeta
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
    }
}
