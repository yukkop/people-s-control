using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IUserRoleQuery
    {
        public bool CheckUserPermissions(long userId, string[] roleName);
    }
}
