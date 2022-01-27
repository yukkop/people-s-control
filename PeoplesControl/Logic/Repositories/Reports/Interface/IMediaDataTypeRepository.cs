using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IMediaDataTypeRepository
    {
        public MediaDataType Get(long id);
        public List<MediaDataType> GetAll();
        public MediaDataType Add(MediaDataType mediaDataType); 
        bool Update(MediaDataType entity);
        void SaveChanges();
        void Delete(long id);
    }
}
