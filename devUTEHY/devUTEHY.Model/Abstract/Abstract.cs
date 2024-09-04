using System;
using System.ComponentModel.DataAnnotations;

namespace devUTEHY.Model.Abstract
{
    public abstract class Auditable : IAuditable
    {
        public DateTime? NgayTao { set; get; }

        [MaxLength(256)]
        public string NguoiTao { set; get; }

        public DateTime? NgayCapNhat { set; get; }

        [MaxLength(256)]
        public string NguoiCapNhat { set; get; }

        [MaxLength(256)]
        public string MetaKeyword { set; get; }

        [MaxLength(256)]
        public string MetaDescription { set; get; }

        public bool TrangThai { set; get; }
    }
}
