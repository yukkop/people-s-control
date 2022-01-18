using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    class Profile
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Sername { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string EmaleAdress { get; set; }
        public District Location { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyBySMS { get; set; }
        public bool RequestAnonymity { get; set; }
        public float TrustRating { get; set; }
        public ActionMeta Removal { get; set; }
        public ActionMeta LastEditing { get; set; }
        public ActionMeta Creation { get; set; }
        public ActionMeta Block { get; set; }
    }
}
