using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Entities
{
    public class Title
    {
        [Key]
        public int titleId { get; set; }

        [Required]
        [MaxLength(20)]
        public string titleName { get; set; }
    }
}
