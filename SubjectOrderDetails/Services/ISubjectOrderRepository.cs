using SubjectOrderDetails.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubjectOrderDetails.Services
{
    /// <summary>
    /// Interface for subjectorder repository
    /// </summary>
    public interface ISubjectOrderRepository
    {

        /// <summary>
        /// Get all subjects
        /// </summary>
        /// <returns></returns>
        IEnumerable<Subject> GetSubjects();

        /// <summary>
        /// Get one subject
        /// </summary>
        /// <param name="subjectId">The ID of the subjec to return</param>
        /// <returns></returns>
        Subject GetSubject(int subjectId);

        /// <summary>
        /// Add a subject
        /// </summary>
        /// <param name="subject">The subject to add</param>
        void AddSubject(Subject subject);

        /// <summary>
        /// Delete a subject
        /// </summary>
        /// <param name="subject">The subject to delete</param>
        void DeleteSubject(Subject subject);

        /// <summary>
        /// Update a subject
        /// </summary>
        /// <param name="subject">The subject to update</param>
        void UpdateSubject(Subject subject);

        /// <summary>
        /// Check that a subject exists
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        bool SubjectExists(int subjectId);

        /// <summary>
        /// Get all titles
        /// </summary>
        /// <returns></returns>
        IEnumerable<Title> GetTitles();

        /// <summary>
        /// Save the changes
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
