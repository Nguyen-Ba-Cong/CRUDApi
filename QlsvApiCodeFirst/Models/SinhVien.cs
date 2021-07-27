using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QlsvApi.Models
{
    public class SinhVien
    {
        [Key]
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "float(2)")]
        public double Score { get; set; }


    }
}
