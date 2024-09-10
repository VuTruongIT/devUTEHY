using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devUTEHY.Model.Models
{
    [Table("CongNgheTags")]
    public class CongNgheTags
    {
        [Key]
        [Column(Order = 1)]
        public int CongNgheID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("CongNgheID")]
        public virtual CongNghe CongNghe { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}
