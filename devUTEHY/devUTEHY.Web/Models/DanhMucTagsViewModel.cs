using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devUTEHY.Web.Models
{
    public class DanhMucTagsViewModel
    {
        public int DanhMucID { set; get; }

        public string TagID { set; get; }

        public virtual DanhMucViewModel DanhMuc { set; get; }

        public virtual TagViewModel Tag { set; get; }
    }
}