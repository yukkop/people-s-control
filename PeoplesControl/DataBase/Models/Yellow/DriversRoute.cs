using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class DriversRoute
    {
        public long Id { get; set; }
        public Driver Driver { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public string VehicleNumber { get; set; }
    }
}
