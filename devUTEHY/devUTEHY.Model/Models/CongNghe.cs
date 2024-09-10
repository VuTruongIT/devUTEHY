using devUTEHY.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devUTEHY.Model.Models
{
    [Table("CongNghe")]
    public class CongNghe : Auditable
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

        public virtual IEnumerable<CongNgheTags> CongNgheTags { set; get; }
    }
}
