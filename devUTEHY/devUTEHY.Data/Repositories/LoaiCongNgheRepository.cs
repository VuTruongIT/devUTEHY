using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface ILoaiCongNgheRepository : IRepository<LoaiCongNghe>
    {
    }

    public class LoaiCongNgheRepository : RepositoryBase<LoaiCongNghe>, ILoaiCongNgheRepository
    {
        public LoaiCongNgheRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}