using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class GetUserProfileDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public long DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long CityId { get; set; }
        public string CityName { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyBySMS { get; set; }
        public byte[] Avatar { get; set; }
    }
}
