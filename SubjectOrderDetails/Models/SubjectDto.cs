using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    public class SubjectDto
    {
        public int subjectId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTimeOffset dateofBirth { get; set; }
    }
}
