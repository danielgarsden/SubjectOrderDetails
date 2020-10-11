using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    /// <summary>
    /// Data transfer object for Title
    /// </summary>
    public class TitleDto
    {
        /// <summary>
        /// Id of the title
        /// </summary>
        public int titleId { get; set; }

        /// <summary>
        /// Name of the title
        /// </summary>
        public string titleName { get; set; }
    }
}
