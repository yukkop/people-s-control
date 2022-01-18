using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class ReportView
    {
        public long Id { get; set; }
        public User User { get; set; }
        public Report Report { get; set; }
    }
}
