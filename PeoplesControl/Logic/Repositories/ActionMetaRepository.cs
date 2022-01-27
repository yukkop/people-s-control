using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using DataBase.Models;

namespace Logic.Repositories
{
    public class ActionMetaRepository : IActionMetaRepository
    {
        IWebContext _context;

        public ActionMetaRepository(IWebContext context)
        {
            _context = context;
        }

        public ActionMeta Add(ActionMeta entity)
        {
            return _context.ActionMeta.Add(entity).Entity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
