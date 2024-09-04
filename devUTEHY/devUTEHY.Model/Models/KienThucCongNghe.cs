using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;
using devUTEHY.Model.Abstract;

namespace devUTEHY.Model.Models
{
    [Table("KienThucCongNghe")]
    public class KienThucCongNghe : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        [MaxLength(500)]
        public string ChuDe { set; get; }

        [Required]
        [MaxLength(500)]
        public string TieuDe { set; get; }

        [Required]
        [MaxLength(500)]
        public string MoTa { set; get; }

        [MaxLength(500)]
        public string LinkTaiLieu { set; get; }

        [Required]
        public int KhoaHocID { set; get; }

        [ForeignKey("KhoaHocID")]
        public virtual KhoaHoc KhoaHoc { set; get; }

        public int? STT { set; get; }

        public string Tags { set; get; }

        public bool? HienThiDanhMuc { set; get; }

        public virtual IEnumerable<KienThucCongNgheTags> KienThucCongNgheTags { set; get; }
    }
}