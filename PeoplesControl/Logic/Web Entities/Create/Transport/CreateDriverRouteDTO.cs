using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateDriverRouteDTO
    {
        public long DriverId { get; set; }
        public long TransportRouteId { get; set; }
        public string VehicleNumber { get; set; }
    }
}
