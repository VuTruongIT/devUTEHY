namespace devUTEHY.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private devUTEHYDbContext dbContext;

        public devUTEHYDbContext Init()
        {
            return dbContext ?? (dbContext = new devUTEHYDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}