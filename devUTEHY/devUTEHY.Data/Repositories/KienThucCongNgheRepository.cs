using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface IKienThucCongNgheRepository : IRepository<KienThucCongNghe>
    {
    }

    public class KienThucCongNgheRepository : RepositoryBase<KienThucCongNghe>, IKienThucCongNgheRepository
    {
        public KienThucCongNgheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}