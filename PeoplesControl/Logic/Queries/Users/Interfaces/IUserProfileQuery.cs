using Logic.WebEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Queries
{
    public interface IUserProfileQuery
    {
        public UserProfileDTO Get(long id);
    }
}
