using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class TransportRoute
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int number { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
    }
}
