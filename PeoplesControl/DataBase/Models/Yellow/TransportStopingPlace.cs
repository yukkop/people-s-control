using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class TransportStopingPlace
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public TransportCompanie ManagementCompanies { get; set; }
        public Сoordinates Сoordinates { get; set; }
        public City City { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
