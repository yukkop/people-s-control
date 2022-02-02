using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class HCSByRegion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long HCSId { get; set; }
        public HCS HCS { get; set; }
        public long RegionId { get; set; }
        public Region Region { get; set; }
    }
}
