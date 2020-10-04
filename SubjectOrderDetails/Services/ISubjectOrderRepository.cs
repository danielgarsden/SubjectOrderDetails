using SubjectOrderDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Services
{
    public interface ISubjectOrderRepository
    {

        IEnumerable<Subject> GetSubjects();
        Subject GetSubject(int subjectId);

        void AddSubject(Subject subject);
        void DeleteSubject(Subject subject);
        void UpdateSubject(Subject subject);
        bool SubjectExists(int subjectId);
        bool Save();
    }
}
