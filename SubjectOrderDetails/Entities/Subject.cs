using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Entities
{

    /// <summary>
    /// Subject Entity
    /// </summary>
    public class Subject
    {

        /// <summary>
        /// Subject ID
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subjectId { get; set; }

        /// <summary>
        /// Subjects first name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        /// <summary>
        /// Subjects last name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }

        /// <summary>
        /// Subjects date of birth
        /// </summary>
        [Required]
        public DateTimeOffset dateOfBirth { get; set; }

        /// <summary>
        /// Title object of the this subject
        /// </summary>
        [ForeignKey("titleId")]
        public Title Title { get; set; }


        /// <summary>
        /// Title ID of the subject
        /// </summary>
        public int titleId { get; set; }

    }
}
