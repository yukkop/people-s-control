using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.WebEntities
{
    public class RegistrationDTO
    {
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public long? DistrictId { get; set; }
    }
}
