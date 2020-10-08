using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    public class SubjectDto
    {
        [Required]
        public int subjectId { get; set; }

        [Required]
        public string firstName { get; set; }

        [Required]
        public string lastName { get; set; }

        [Required]
        public DateTimeOffset dateOfBirth { get; set; }

        [Required]
        public int titleId { get; set; }
    }
}
