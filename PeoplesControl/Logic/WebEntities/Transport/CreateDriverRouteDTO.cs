using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateDriverRouteDTO
    {
        public long DriverId { get; set; }
        public long TransportRouteId { get; set; }
        public string VehicleNumber { get; set; }
    }
}
