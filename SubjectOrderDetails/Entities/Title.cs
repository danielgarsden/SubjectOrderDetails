using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Entities
{
    /// <summary>
    /// A title object containing title Id and title name
    /// </summary>
    public class Title
    {
        /// <summary>
        /// ID of the title
        /// </summary>
        [Key]
        public int titleId { get; set; }

        /// <summary>
        /// The title name
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string titleName { get; set; }
    }
}
