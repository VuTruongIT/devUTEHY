using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface ICongNgheTagsRepository : IRepository<CongNgheTags>
    {
    }

    public class CongNgheTagsRepository : RepositoryBase<CongNgheTags>, ICongNgheTagsRepository
    {
        public CongNgheTagsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}