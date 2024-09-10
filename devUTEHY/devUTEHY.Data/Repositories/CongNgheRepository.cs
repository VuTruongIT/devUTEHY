using devUTEHY.Data.Infrastructure;
using System.Linq;
using devUTEHY.Model.Models;
using System.Collections.Generic;

namespace devUTEHY.Data.Repositories
{
    public interface ICongNgheRepository : IRepository<CongNghe>
    {

    }

    public class CongNgheRepository : RepositoryBase<CongNghe>, ICongNgheRepository
    {
        public CongNgheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        
    }
}