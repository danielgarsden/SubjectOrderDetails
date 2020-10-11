using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    /// <summary>
    /// DTO to be used for creating subjects
    /// </summary>
    public class SubjectForCreationDto
    {
        /// <summary>
        /// Subject first name
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
        ///  Subjects date of birth
        /// </summary>
        [Required]
        public DateTimeOffset dateOfBirth { get; set; }

        /// <summary>
        /// Title ID for the subject
        /// </summary>
        [Required]
        public int titleId { get; set; }
    }
}
