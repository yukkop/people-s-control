using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateDraftReportDTO
    {
        public string Title { get; set; }
        public long UserId { get; set; }
        public NpgsqlPoint Сoordinates { get; set; }
        public string Description { get; set; }
    }
}
