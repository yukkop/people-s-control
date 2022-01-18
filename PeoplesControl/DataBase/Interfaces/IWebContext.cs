using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataBase
{
    interface IWebContext
    {
        public System.Threading.Tasks.Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
        public bool SaveChanges();
        public bool Update<TEntity>(TEntity entity);
    }
}
