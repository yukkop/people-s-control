using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    // Черновики заявок
    public class DraftReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public NpgsqlPoint Сoordinates { get; set; }
        public string ProblemDescription { get; set; }
        public DateTime? DateRemoval { get; set; }
        public DateTime? DateLastEditing { get; set; }
        public DateTime? DateCreation { get; set; }
    }
}
