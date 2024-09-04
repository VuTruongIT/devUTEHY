using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devUTEHY.Model.Models
{
    [Table("KhoaHocTags")]
    public class KhoaHocTags
    {
        [Key]
        [Column(Order = 1)]
        public int KhoaHocID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("KhoaHocID")]
        public virtual KhoaHoc KhoaHoc { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}