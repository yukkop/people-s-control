using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IMediaDataType
    {
        public MediaDataType Get(int id);
        public List<MediaDataType> GetAll();
        public MediaDataType Add(MediaDataType mediaDataType);
    }
}
