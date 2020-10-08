using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubjectOrderDetails.Entities;
using SubjectOrderDetails.Services;

namespace SubjectOrderDetailsTests
{
    public class FakeSubjectOrderRepository : ISubjectOrderRepository
    {
        private readonly List<Subject> _subject;

        public FakeSubjectOrderRepository()
        {
            _subject = new List<Subject>()
            {
                new Subject()
                {
                    subjectId = 1,
                    firstName = "Daniel",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(1976, 8, 19),
                    titleId = 1
                },
                new Subject()
                {
                    subjectId = 1,
                    firstName = "Tamas",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(2015, 11, 29),
                    titleId = 1
                },
                new Subject()
                {
                    subjectId = 1,
                    firstName = "Alma",
                    lastName = "Garsden",
                    dateOfBirth = new DateTime(2017, 11, 16),
                    titleId = 1
                }
            };
        }

        public void AddSubject(Subject subject)
        {
            subject.subjectId = 4;
            _subject.Add(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            _subject.Remove(subject);
        }

        public Subject GetSubject(int subjectId)
        {
            return _subject.Where(s => s.subjectId == subjectId).FirstOrDefault();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subject;
        }

        public IEnumerable<Title> GetTitles()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            // No implementation
            return true;
        }

        public bool SubjectExists(int subjectId)
        {
            throw new NotImplementedException();
        }

        public void UpdateSubject(Subject subject)
        {
            // no code implentation here
        }
    }
}
