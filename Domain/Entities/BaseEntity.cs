using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("UpdatedDateTime")]
        public DateTime? UpdatedDateTime { get; set; }

        [Column("CreatedBy")]
        public string CreatedBy { get; set; }

        [Column("UpdatedBy")]
        public string UpdatedBy { get; set; }
    }
}
