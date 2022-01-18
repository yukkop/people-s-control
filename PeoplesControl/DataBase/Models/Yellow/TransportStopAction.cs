using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class TransportStopAction
    {
        public long Id { get; set; }
        public StopOnRoute StopingPointOnRoute { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }
    }
}
