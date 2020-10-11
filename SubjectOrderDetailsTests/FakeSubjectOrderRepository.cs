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
        private readonly List<Subject> _subjects;
        private readonly List<Title> _titles;

        public FakeSubjectOrderRepository()
        {
            _subjects = new List<Subject>()
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

            _titles = new List<Title>()
            {
                new Title()
                {
                    titleId = 1,
                    titleName = "Mr"
                },
                new Title()
                {
                    titleId = 2,
                    titleName = "Mrs"
                },
                new Title()
                {
                    titleId = 3,
                    titleName = "Master"
                },
                new Title()
                {
                    titleId = 4,
                    titleName = "Miss"
                },
                new Title()
                {
                    titleId = 5,
                    titleName = "Dr"
                }
            };
        }

        public void AddSubject(Subject subject)
        {
            subject.subjectId = 4;
            _subjects.Add(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            _subjects.Remove(subject);
        }

        public Subject GetSubject(int subjectId)
        {
            return _subjects.Where(s => s.subjectId == subjectId).FirstOrDefault();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjects;
        }

        public IEnumerable<Title> GetTitles()
        {
            return _titles;
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
