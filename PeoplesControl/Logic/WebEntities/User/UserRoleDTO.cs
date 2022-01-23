using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;

namespace Logic.WebEntities
{
    class UserRoleDTO
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
