using devUTEHY.Model.Models;
using System;
using System.Collections.Generic;

namespace devUTEHY.Web.Models
{
    public class LoaiCongNgheViewModel
    {
        public int ID { set; get; }
        public string Ten { set; get; }
        public string TieuDeSEO { set; get; }
        public string MoTa { set; get; }
        public int? ParentID { set; get; }
        public int? ThuTu { set; get; }
        public bool? HienThiTrangChu { set; get; }
        public virtual IEnumerable<KhoaHoc> KhoaHocs { set; get; }
        public virtual IEnumerable<CongNghe> CongNghes { set; get; }


        public DateTime? NgayTao { set; get; }
        public string NguoiTao { set; get; }
        public DateTime? NgayCapNhat { set; get; }
        public string NguoiCapNhat { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public bool TrangThai { set; get; }
    }
}