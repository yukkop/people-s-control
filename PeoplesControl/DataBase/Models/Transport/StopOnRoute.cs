using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class StopOnRoute
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TransportStopId { get; set; }
        public TransportStop TransportStop { get; set; }
        public long TransportRouteId { get; set; }
        public TransportRoute TransportRoute { get; set; }
        public int PositionNumber { get; set; }
        public bool IsStart { get; set; }
        public bool IsFinish { get; set; }
    }
}
