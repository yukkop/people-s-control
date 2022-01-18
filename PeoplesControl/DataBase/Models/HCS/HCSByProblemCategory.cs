using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class HCSByProblemCategory
    {
        public long Id { get; set; }
        public HCS HCS { get; set; }
        public ProblemCategory ProblemCategory { get; set; }
    }
}
