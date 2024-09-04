using devUTEHY.Data.Infrastructure;
using System.Linq;
using devUTEHY.Model.Models;
using System.Collections.Generic;

namespace devUTEHY.Data.Repositories
{
    public interface IKhoaHocRepository : IRepository<KhoaHoc>
    {
        IEnumerable<KhoaHoc> GetListKhoaHocByTag(string tagId, int page, int pageSize, out int totalRow);
    }

    public class KhoaHocRepository : RepositoryBase<KhoaHoc>, IKhoaHocRepository
    {
        public KhoaHocRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<KhoaHoc> GetListKhoaHocByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.KhoaHocs
                        join pt in DbContext.KhoaHocTags
                        on p.ID equals pt.KhoaHocID
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();

            return query.OrderByDescending(x => x.NgayTao).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}