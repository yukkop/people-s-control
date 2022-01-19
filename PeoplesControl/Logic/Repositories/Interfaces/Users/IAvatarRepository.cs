using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;

namespace Logic.Repositories
{
    public interface IAvatarRepository
    {
        public Avatar Get(int id);
        public List<Avatar> GetAll();
        public Avatar Add(Avatar avatar);
    }
}
