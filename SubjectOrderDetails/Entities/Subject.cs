using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Entities
{
    public class Subject
    {

        [Key]
        public int subjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        [MaxLength(100)]
        public string lastnameName { get; set; }

        public DateTimeOffset dateofBirth { get; set; }

    }
}
