using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities.Create.Transport
{
    class CreateStopOnRouteDTO
    {
        public long TransportStopId { get; set; }
        public long TransportRouteId { get; set; }
        public int PositionNumber { get; set; }
        public bool IsStart { get; set; }
        public bool IsFinish { get; set; }
    }
}
