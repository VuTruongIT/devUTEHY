using devUTEHY.Data.Infrastructure;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface IDanhMucTagsRepository : IRepository<DanhMucTags>
    {
    }

    public class DanhMucTagsRepository : RepositoryBase<DanhMucTags>, IDanhMucTagsRepository
    {
        public DanhMucTagsRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}