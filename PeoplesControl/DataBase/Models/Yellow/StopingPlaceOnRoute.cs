using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class StopingPlaceOnRoute
    {
        public long Id { get; set; }
        public TransportStopingPlace TransportStop { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public int PositionNumber { get; set; }
        public bool IsStart { get; set; }
        public bool IsFinish { get; set; }
    }
}
