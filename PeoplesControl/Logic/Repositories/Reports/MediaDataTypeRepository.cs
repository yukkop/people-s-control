using DataBase;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic.Repositories
{
    public class MediaDataTypeRepository : IMediaDataTypeRepository
    {
        IWebContext _context;
        public MediaDataTypeRepository(IWebContext context)
        {
            _context = context;
        }

        public MediaDataType Add(MediaDataType entity)
        {
            return _context.MediaDataTypes.Add(entity).Entity;
        }

        public MediaDataType Get(long id)
        {
            return _context.MediaDataTypes.Where(entity => entity.Id == id).FirstOrDefault();
        }

        public List<MediaDataType> GetAll()
        {
            return _context.MediaDataTypes.ToList();
        }

        public bool Update(MediaDataType entity)
        {
            return _context.Update(entity);
            
        }
        public void Delete(long id)
        {
            _context.MediaDataTypes.Remove(_context.MediaDataTypes.Where(i => i.Id == id).FirstOrDefault());
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
