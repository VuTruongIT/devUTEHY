using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface IKhoaHocTagsRepository : IRepository<KhoaHocTags>
    {
    }

    public class KhoaHocTagsRepository : RepositoryBase<KhoaHocTags>, IKhoaHocTagsRepository
    {
        public KhoaHocTagsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}