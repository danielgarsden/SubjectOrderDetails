using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Models
{
    public class SubjectForCreationDto
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTimeOffset dateOfBirth { get; set; }

        public int titleId { get; set; }
    }
}
