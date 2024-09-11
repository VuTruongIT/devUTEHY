using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devUTEHY.Model.Models
{
    [Table("DanhMucTags")]
    public class DanhMucTags
    {
        [Key]
        [Column(Order = 1)]
        public int DanhMucID { set; get; }

        [Key]
        [Column(TypeName = "varchar", Order = 2)]
        [MaxLength(50)]
        public string TagID { set; get; }

        [ForeignKey("DanhMucID")]
        public virtual DanhMuc DanhMuc { set; get; }

        [ForeignKey("TagID")]
        public virtual Tag Tag { set; get; }
    }
}
