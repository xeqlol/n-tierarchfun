using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private StoreEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        // simplest way to implement singleton pattern
        public StoreEntities DbContext
        {
            get { return dbContext ?? (dbContext = new StoreEntities()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
