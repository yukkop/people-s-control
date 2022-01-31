using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;

namespace Logic.Repositories
{
    public interface IActionMetaRepository
    {
        public ActionMeta Add(ActionMeta actionMeta);
        public void SaveChanges();
    }
}
