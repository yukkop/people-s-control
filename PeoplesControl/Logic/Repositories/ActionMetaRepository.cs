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
            context = _context;
        }

        public ActionMeta Add(ActionMeta entity)
        {
            return _context.ActionMeta.Add(entity).Entity;
        }

        public ActionMeta Update(long id, ActionMeta newEntity)
        {
            ActionMeta oldEntity = _context.ActionMeta.Where(item => item.Id == id).FirstOrDefault();
            return oldEntity;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public ActionMeta Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<ActionMeta> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
