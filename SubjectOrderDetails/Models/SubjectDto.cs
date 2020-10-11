using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    /// <summary>
    /// A subject with SubjectID, first name, last name, date of birth and titleid
    /// </summary>
    public class SubjectDto
    {
        /// <summary>
        /// The ID of the subject
        /// </summary>
        [Required]
        public int subjectId { get; set; }

        /// <summary>
        /// The first name of the subject
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string firstName { get; set; }

        /// <summary>
        /// The last name of the subject
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string lastName { get; set; }

        /// <summary>
        /// The subjects date of birth
        /// </summary>
        [Required]
        public DateTimeOffset dateOfBirth { get; set; }

        /// <summary>
        /// The title id of the subject
        /// </summary>
        [Required]
        public int titleId { get; set; }
    }
}
