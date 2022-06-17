using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace userGRPC.Entity
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string NameWithInitail { get; set; }

        [Required]
        public double Mark1 { get; set; }

        [Required]
        public double Mark2 { get; set; }

        [Required]
        public double Mark3 { get; set; }

        [Required]
        public int Position { get; set; }
    }
}
