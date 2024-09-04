﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace devUTEHY.Model.Models
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        public int ID { set; get; }
        public string Message { set; get; }
        public string StackTrace { set; get; }
        public DateTime CreateDate { set; get; }
    }
}
