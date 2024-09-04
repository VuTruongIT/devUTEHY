using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using devUTEHY.Model.Abstract;

namespace devUTEHY.Model.Models
{
    [Table("KhoaHoc")]
    public class KhoaHoc : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(100)]
        public string Ten { set; get; }

        [Required]
        [MaxLength(100)]
        public string TieuDe { set; get; }

        [MaxLength(500)]
        public string MoTa { set; get; }

        [Required]
        public int LoaiCongNgheID { set; get; }

        [ForeignKey("LoaiCongNgheID")]
        public virtual LoaiCongNghe LoaiCongNghe { set; get; }

        [MaxLength(256)]
        public string Icon { set; get; }

        [MaxLength(256)]
        public string Logo { set; get; }

        [Required]
        [MaxLength(100)]
        public string PhienBan { set; get; }

        public int? STT { set; get; }

        public string Tags { set; get; }

        public bool? HienThiTrangChu { set; get; }

        public bool? HienThiHot { set; get; }

        public virtual IEnumerable<KhoaHocTags> KhoaHocTags { set; get; }
    }
}