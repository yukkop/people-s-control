﻿using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class GetDraftReportDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        public NpgsqlPoint Сoordinates { get; set; }
        public string Description { get; set; }
    }
}
