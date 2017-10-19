using System;

namespace Store.Data.Infrastructure
{
    // why disposable? because we also want to close db connection when GC comes
    public interface IDbFactory : IDisposable
    {
        StoreEntities Init();
    }
}
