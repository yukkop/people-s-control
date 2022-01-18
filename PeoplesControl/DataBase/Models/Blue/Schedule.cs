using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Schedule
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public HCS HCS { get; set; }

    }
}
