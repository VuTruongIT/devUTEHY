using System;

namespace devUTEHY.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        devUTEHYDbContext Init();
    }
}