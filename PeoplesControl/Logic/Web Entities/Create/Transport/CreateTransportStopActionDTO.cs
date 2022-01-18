using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateTransportStopActionDTO
    {
        public long StopingPointOnRouteId { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public TimeSpan DepartureTime { get; set; }

    }
}
