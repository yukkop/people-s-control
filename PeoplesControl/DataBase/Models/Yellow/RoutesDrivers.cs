using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class RoutesDrivers
    {
        public long Id { get; set; }
        public Drivers Drivers { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public string VehicleNumber { get; set; }
    }
}
