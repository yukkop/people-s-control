using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class CreateProfileDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public long LocationId { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyBySMS { get; set; }
        public bool RequestAnonymity { get; set; }
        //public float TrustRating { get; set; } // Это тоже запросом
        public bool IsBlock { get; set; }
        public long BlockId { get; set; }
        public long UnblockId { get; set; }
    }
}
