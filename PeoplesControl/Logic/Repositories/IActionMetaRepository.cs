using System;
using System.Collections.Generic;
using System.Text;
using DataBase.Models;

namespace Logic.Repositories
{
    public interface IActionMetaRepository
    {
        public ActionMeta Get(int id);
        public List<ActionMeta> GetAll();
        public ActionMeta Add(ActionMeta actionMeta);
    }
}
