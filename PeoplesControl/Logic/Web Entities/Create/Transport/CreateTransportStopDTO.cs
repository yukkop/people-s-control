using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Web_Entities
{
    public class CreateTransportStopDTO
    {
        public string Name { get; set; }
        public long ManagementCompanyId { get; set; }
        public NpgsqlPoint Сoordinates { get; set; }
        public long CityId { get; set; }
        public long UserId { get; set; }
    }
}
