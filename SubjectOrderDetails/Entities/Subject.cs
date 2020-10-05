using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Entities
{
    public class Subject
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subjectId { get; set; }

        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        [MaxLength(100)]
        public string lastName { get; set; }

        public DateTimeOffset dateOfBirth { get; set; }

        [ForeignKey("titleId")]
        public Title Title { get; set; }

        public int titleId { get; set; }

    }
}
