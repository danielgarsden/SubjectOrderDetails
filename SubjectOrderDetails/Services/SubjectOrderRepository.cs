using SubjectOrderDetails.DbContexts;
using SubjectOrderDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Services
{
    public class SubjectOrderRepository : ISubjectOrderRepository, IDisposable
    {
        private readonly SubjectOrderContext _context; 

        public SubjectOrderRepository(SubjectOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            _context.Subjects.Add(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            _context.Subjects.Remove(subject);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Subject GetSubject(int subjectId)
        {
            return _context.Subjects.FirstOrDefault(s => s.subjectId == subjectId);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subjects.ToList<Subject>();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool SubjectExists(int subjectId)
        {
            return _context.Subjects.Any(s => s.subjectId == subjectId);
        }

        public void UpdateSubject(Subject subject)
        {
            // no code implementation here
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
