using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using devUTEHY.Model.Abstract;

namespace devUTEHY.Model.Models
{
    [Table("LoaiCongNghe")]
    public class LoaiCongNghe : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(256)]
        public string Ten { set; get; }

        [Required]
        [MaxLength(256)]
        public string TieuDeSEO { set; get; }

        [MaxLength(500)]
        public string MoTa { set; get; }

        public int? ParentID { set; get; }

        public int? ThuTu { set; get; }

        public bool? HienThiTrangChu { set; get; }

        public virtual IEnumerable<KhoaHoc> KhoaHocs { set; get; }
        public virtual IEnumerable<CongNghe> CongNghes { set; get; }


    }
}
