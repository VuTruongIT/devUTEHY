using devUTEHY.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace devUTEHY.Web.Models
{
    public class CongNgheViewModel
    {
        public int ID { set; get; }
        public string Ten { set; get; }
        public string TieuDe { set; get; }
        public string MoTa { set; get; }
        public int LoaiCongNgheID { set; get; }
        public string Icon { set; get; }
        public string Logo { set; get; }
        public string PhienBan { set; get; }
        public int? STT { set; get; }
        public string Tags { set; get; }
        public bool? HienThiTrangChu { set; get; }
        public bool? HienThiHot { set; get; }


        public DateTime? NgayTao { set; get; }
        public string NguoiTao { set; get; }
        public DateTime? NgayCapNhat { set; get; }
        public string NguoiCapNhat { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public bool TrangThai { set; get; }

        public virtual LoaiCongNgheViewModel LoaiCongNghe { set; get; }

    }
}