using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.ResourceParameters
{
    /// <summary>
    /// Class to represent the parameters that can be used to seach for subjects
    /// </summary>
    public class SubjectResourceParameters
    {
        const int maxPageSize = 20;

        /// <summary>
        /// Subjects first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Subjects last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// PageNumber to allow paging
        /// </summary>
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 2;

        /// <summary>
        /// PageSize to allow paging
        /// </summary>
        public int PageSize
        { 
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value; 
        }
    }
}
