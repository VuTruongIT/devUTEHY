using System;

namespace devUTEHY.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? NgayTao { set; get; }
        string NguoiTao { set; get; }
        DateTime? NgayCapNhat { set; get; }
        string NguoiCapNhat { set; get; }

        string MetaKeyword { set; get; }
        string MetaDescription { set; get; }
        bool TrangThai { set; get; }
    }
}
