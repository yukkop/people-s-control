using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models.Purple
{
    class UsersRoles
    {
        public long Id { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
    }
}
