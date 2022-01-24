using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IUserQuery
    {
        public UserDTO Get(long id);
        public UserPasswordDTO FindUserByLogin(string login);
    }
}
