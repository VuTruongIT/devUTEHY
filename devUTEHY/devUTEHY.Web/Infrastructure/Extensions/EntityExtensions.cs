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

        public static void UpdateCongNghe(this CongNghe congNghe, CongNgheViewModel congNgheVm)
        {
            congNghe.ID = congNgheVm.ID;
            congNghe.Ten = congNgheVm.Ten;
            congNghe.TieuDe = congNgheVm.TieuDe;
            congNghe.MoTa = congNgheVm.MoTa;
            congNghe.LoaiCongNgheID = congNgheVm.LoaiCongNgheID;
            congNghe.Icon = congNgheVm.Icon;
            congNghe.Logo = congNgheVm.Logo;
            congNghe.PhienBan = congNgheVm.PhienBan;
            congNghe.STT = congNgheVm.STT;
            congNghe.Tags = congNgheVm.Tags;
            congNghe.HienThiTrangChu = congNgheVm.HienThiTrangChu;
            congNghe.HienThiHot = congNgheVm.HienThiHot;

            congNghe.NgayTao = congNgheVm.NgayTao;
            congNghe.NguoiTao = congNgheVm.NguoiTao;
            congNghe.NgayCapNhat = congNgheVm.NgayCapNhat;
            congNghe.NguoiCapNhat = congNgheVm.NguoiCapNhat;
            congNghe.MetaKeyword = congNgheVm.MetaKeyword;
            congNghe.MetaDescription = congNgheVm.MetaDescription;
            congNghe.TrangThai = congNgheVm.TrangThai;

        }


        public static void UpdateDanhMuc(this DanhMuc danhMuc, DanhMucViewModel danhMucVm)
        {
            danhMuc.ID = danhMucVm.ID;
            danhMuc.Ten = danhMucVm.Ten;
            danhMuc.TieuDe = danhMucVm.TieuDe;
            danhMuc.MoTa = danhMucVm.MoTa;
            danhMuc.CongNgheID = danhMucVm.CongNgheID;
            danhMuc.STT = danhMucVm.STT;
            danhMuc.Tags = danhMucVm.Tags;
            danhMuc.HienThiTrangChu = danhMucVm.HienThiTrangChu;

            danhMuc.NgayTao = danhMucVm.NgayTao;
            danhMuc.NguoiTao = danhMucVm.NguoiTao;
            danhMuc.NgayCapNhat = danhMucVm.NgayCapNhat;
            danhMuc.NguoiCapNhat = danhMucVm.NguoiCapNhat;
            danhMuc.MetaKeyword = danhMucVm.MetaKeyword;
            danhMuc.MetaDescription = danhMucVm.MetaDescription;
            danhMuc.TrangThai = danhMucVm.TrangThai;

        }
    }
}