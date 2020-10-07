using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SubjectOrderDetails.Controllers;
using SubjectOrderDetails.Models;
using System.Collections.Generic;

namespace SubjectOrderDetailsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetSubjects_ReturnsOkResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubjects();

            // assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetSubjects_ReturnsSubjectDtoList()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubjects().Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<List<SubjectDto>>(result.Value);
        }


        [Test]
        public void GetSubjects_ReturnsAllItems()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubjects().Result as OkObjectResult;
            List<SubjectDto> subjects =  result.Value as List<SubjectDto>;

            // assert
            Assert.AreEqual(3, subjects.Count);
        }

        [Test]
        public void GetSubject_ValidSubject_ReturnsOkResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubject(1);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetSubject_InValidSubject_ReturnsNotFoundResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubject(4);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }

        [Test]
        public void GetSubject_ReturnsCorrectSubject()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubject(1).Result as OkObjectResult;
            SubjectDto subject = result.Value as SubjectDto;

            // assert
            Assert.AreEqual(1, subject.subjectId);
            Assert.AreEqual("Daniel", subject.firstName);
            Assert.AreEqual("Garsden", subject.lastName);
            Assert.AreEqual("19/08/1976", subject.dateOfBirth.ToString("d"));
        }

    }
}