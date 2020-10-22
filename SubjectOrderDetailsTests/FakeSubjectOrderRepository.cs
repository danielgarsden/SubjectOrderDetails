using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubjectOrderDetails.Entities;
using SubjectOrderDetails.Services;
using SubjectOrderDetails.ResourceParameters;
using SubjectOrderDetails.Helpers;

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
                    SubjectId = 1,
                    FirstName = "Daniel",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(1976, 8, 19),
                    TitleId = 1
                },
                new Subject()
                {
                    SubjectId = 2,
                    FirstName = "Tamas",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(2015, 11, 29),
                    TitleId = 1
                },
                new Subject()
                {
                    SubjectId = 3,
                    FirstName = "Alma",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(2017, 11, 16),
                    TitleId = 1
                },
                 new Subject()
                {
                    SubjectId = 4,
                    FirstName = "Phillip",
                    LastName = "Garsden",
                    DateOfBirth = new DateTime(1949, 10, 05),
                    TitleId = 4
                },
                 new Subject()
                 {
                     SubjectId = 5,
                     FirstName = "Jennifer",
                     LastName = "Garsden",
                     DateOfBirth = new DateTime(1986, 07, 17),
                     TitleId = 4
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
            subject.SubjectId = 6;
            _subjects.Add(subject);
        }

        public void DeleteSubject(Subject subject)
        {
            _subjects.Remove(subject);
        }

        public Subject GetSubject(int subjectId)
        {
            return _subjects.Where(s => s.SubjectId == subjectId).FirstOrDefault();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjects;
        }

        public PagedList<Subject> GetSubjects(SubjectResourceParameters subjectResourceParameters)
        {
            //return _subjects;
            throw new NotImplementedException();
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
