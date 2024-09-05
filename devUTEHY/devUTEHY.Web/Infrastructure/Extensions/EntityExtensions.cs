using devUTEHY.Model.Models;
using devUTEHY.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace devUTEHY.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateLoaiCongNghe(this LoaiCongNghe loaiCongNghe, LoaiCongNgheViewModel loaiCongNgheVm)
        {
            loaiCongNghe.ID = loaiCongNgheVm.ID;
            loaiCongNghe.Ten = loaiCongNgheVm.Ten;
            loaiCongNghe.TieuDeSEO = loaiCongNgheVm.TieuDeSEO;
            loaiCongNghe.MoTa = loaiCongNgheVm.MoTa;
            loaiCongNghe.ParentID = loaiCongNgheVm.ParentID;
            loaiCongNghe.ThuTu = loaiCongNgheVm.ThuTu;
            loaiCongNghe.HienThiTrangChu = loaiCongNgheVm.HienThiTrangChu;

            loaiCongNghe.NgayTao = loaiCongNgheVm.NgayTao;
            loaiCongNghe.NguoiTao = loaiCongNgheVm.NguoiTao;
            loaiCongNghe.NgayCapNhat = loaiCongNgheVm.NgayCapNhat;
            loaiCongNghe.NguoiCapNhat = loaiCongNgheVm.NguoiCapNhat;
            loaiCongNghe.MetaKeyword = loaiCongNgheVm.MetaKeyword;
            loaiCongNghe.MetaDescription = loaiCongNgheVm.MetaDescription;
            loaiCongNghe.TrangThai = loaiCongNgheVm.TrangThai;
        }
    }
}