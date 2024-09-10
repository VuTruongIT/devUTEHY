using devUTEHY.Web.Models;

namespace devUTEHY.Web.Models
{
    public class CongNgheTagsViewModel
    {
        public int CongNgheID { set; get; }

        public string TagID { set; get; }

        public virtual CongNgheViewModel CongNghe { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}