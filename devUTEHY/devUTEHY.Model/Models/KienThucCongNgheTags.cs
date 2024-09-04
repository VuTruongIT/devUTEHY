using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devUTEHY.Model.Models
{
    [Table("KienThucCongNgheTags")]
    public class KienThucCongNgheTags
    {
        [Key]
        [Column(Order = 1)]
        public int KienThucCongNgheID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("KienThucCongNgheID")]
        public virtual KienThucCongNghe KienThucCongNghe { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}