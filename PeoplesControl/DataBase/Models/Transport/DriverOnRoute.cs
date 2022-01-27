using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class DriverOnRoute
    {
        public long Id { get; set; }
        public long DriverId { get; set; }
        public Driver Driver { get; set; }
        public long TransportRouteId { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public string VehicleNumber { get; set; }
    }
}
