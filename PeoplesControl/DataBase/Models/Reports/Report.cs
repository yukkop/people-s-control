using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataBase.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public long? RelationReportId { get; set; }
        public Report? RelationReport { get; set; }
        public string Address { get; set; }
        public long StatusId { get; set; }
        public ReportStatus Status { get; set; }
        public NpgsqlPoint Coordinates { get; set; }
        public DateTime DateConsideration { get; set; }
        public DateTime DateStartExecution { get; set; }
        public DateTime DateFinishExecution { get; set; }
        public DateTime DateFinalControl { get; set; }
        public bool IsRequestModeration { get; set; }
        public long? ModeratorId { get; set; }
        public User? Moderator { get; set; }
        public string ProblemDescription { get; set; }
        public float BaseRate { get; set; }
        public DateTime? DateRemoval { get; set; }
        public DateTime? DateLastEditing { get; set; }
        public DateTime? DateCreation { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAnonymously { get; set; }

        // Рейтинг реализовать запросами
        // Тоже самео с просмотрами
    }
}
