using devUTEHY.Data.Infrastructure;
using System.Linq;
using devUTEHY.Model.Models;

namespace devUTEHY.Data.Repositories
{
    public interface IDanhMucRepository : IRepository<DanhMuc>
    {

    }

    public class DanhMucRepository : RepositoryBase<DanhMuc>, IDanhMucRepository
    {
        public DanhMucRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }


    }
}