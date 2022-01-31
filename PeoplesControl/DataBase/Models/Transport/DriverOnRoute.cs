using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class DriverOnRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long DriverId { get; set; }
        public Driver Driver { get; set; }
        public long TransportRouteId { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public string VehicleNumber { get; set; }
    }
}
