using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Repositories
{
    public interface IMediaDataRepository
    {
        public MediaData Get(int id);
        public List<MediaData> GetAll();
        public MediaData Add(MediaData mediaData);
    }
}
