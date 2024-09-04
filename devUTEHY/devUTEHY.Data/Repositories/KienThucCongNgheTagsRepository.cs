using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface IKienThucCongNgheTagsRepository : IRepository<KienThucCongNgheTags>
    {
    }

    public class KienThucCongNgheTagsRepository : RepositoryBase<KienThucCongNgheTags>, IKienThucCongNgheTagsRepository
    {
        public KienThucCongNgheTagsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}