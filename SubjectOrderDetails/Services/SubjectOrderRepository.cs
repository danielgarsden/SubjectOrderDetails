using SubjectOrderDetails.DbContexts;
using SubjectOrderDetails.Entities;
using SubjectOrderDetails.Helpers;
using SubjectOrderDetails.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Services
{
    /// <summary>
    /// Repository for subject orders
    /// </summary>
    public class SubjectOrderRepository : ISubjectOrderRepository, IDisposable
    {
        private readonly SubjectOrderContext _context; 

        /// <summary>
        /// Constructor that receives the persistence context
        /// </summary>
        /// <param name="context"></param>
        public SubjectOrderRepository(SubjectOrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        /// <summary>
        /// Add a subject
        /// </summary>
        /// <param name="subject">The subject to add</param>
        public void AddSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            _context.Subjects.Add(subject);
        }

        /// <summary>
        /// Delete a subject
        /// </summary>
        /// <param name="subject">The subject to delete</param>
        public void DeleteSubject(Subject subject)
        {
            if (subject == null)
            {
                throw new ArgumentNullException(nameof(subject));
            }

            _context.Subjects.Remove(subject);
        }

        /// <summary>
        /// Dispose object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get a subject
        /// </summary>
        /// <param name="subjectId">The ID of the subject to retrieve</param>
        /// <returns></returns>
        public Subject GetSubject(int subjectId)
        {
            return _context.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);
        }

        /// <summary>
        /// Get all subjects
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Subject> GetSubjects()
        {
            return _context.Subjects.ToList<Subject>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectResourceParameters"></param>
        /// <returns></returns>
        public PagedList<Subject> GetSubjects(SubjectResourceParameters subjectResourceParameters)
        {
            if (subjectResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(subjectResourceParameters));
            }

            //if (string.IsNullOrWhiteSpace(subjectResourceParameters.FirstName) && string.IsNullOrWhiteSpace(subjectResourceParameters.LastName))
            //{
            //    return GetSubjects();
            //}

            var collection = _context.Subjects as IQueryable<Subject>;

            if (!string.IsNullOrWhiteSpace(subjectResourceParameters.FirstName))
            {
                var firstName = subjectResourceParameters.FirstName.Trim();
                collection = collection.Where(a => a.FirstName == firstName);
            }

            if (!string.IsNullOrWhiteSpace(subjectResourceParameters.LastName))
            {
                var lastName = subjectResourceParameters.LastName.Trim();
                collection = collection.Where(a => a.LastName == lastName);
            }



            return PagedList<Subject>.Create(collection, subjectResourceParameters.PageNumber, subjectResourceParameters.PageSize);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Check if a subject exists
        /// </summary>
        /// <param name="subjectId">The subject to check</param>
        /// <returns></returns>
        public bool SubjectExists(int subjectId)
        {
            return _context.Subjects.Any(s => s.SubjectId == subjectId);
        }

        /// <summary>
        /// Update the subject
        /// </summary>
        /// <param name="subject">The subject ot update</param>
        public void UpdateSubject(Subject subject)
        {
            // no code implementation here
        }

        /// <summary>
        /// Get all titles
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Title> GetTitles()
        {
            return _context.Titles.ToList<Title>();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
