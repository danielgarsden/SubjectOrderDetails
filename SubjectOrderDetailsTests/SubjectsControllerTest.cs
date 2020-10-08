using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SubjectOrderDetails.Controllers;
using SubjectOrderDetails.Models;
using System;
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

        [Test]
        public void AddSubject_ValidObject_ReturnsCreateAtRouteResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectForCreationDto subject = new SubjectForCreationDto
            {
                firstName = "Zita",
                lastName = "Garsden Kabok",
                dateOfBirth = new DateTime(1980, 05, 03),
                titleId = 2
            };

            // act
            var result = sc.CreateSubject(subject);

            // assert
            Assert.IsInstanceOf<CreatedAtRouteResult>(result);
        }

        [Test]
        public void AddSubject_ValidObject_ReturnsCreatedSubject()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectForCreationDto subject = new SubjectForCreationDto
            {
                firstName = "Zita",
                lastName = "Garsden Kabok",
                dateOfBirth = new DateTime(1980, 05, 03),
                titleId = 2
            };

            // act
            CreatedAtRouteResult result = sc.CreateSubject(subject) as CreatedAtRouteResult;

            // assert
            Assert.IsInstanceOf<SubjectDto>(result.Value);
            Assert.AreEqual("GetSubject", result.RouteName);

            SubjectDto subjectReturned = result.Value as SubjectDto;

            Assert.AreEqual(4, subjectReturned.subjectId);
            Assert.AreEqual("Zita", subjectReturned.firstName);
            Assert.AreEqual("Garsden Kabok", subjectReturned.lastName);
            Assert.AreEqual("03/05/1980", subject.dateOfBirth.ToString("d"));
            Assert.AreEqual(2, subjectReturned.titleId);

        }

        [Test]
        public void AddSubject_InValidObject_ReturnsBadRequestResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectForCreationDto subject = new SubjectForCreationDto
            {
                lastName = "Garsden Kabok",
                dateOfBirth = new DateTime(1980, 05, 03),
                titleId = 2
            };
            sc.ModelState.AddModelError("firstName", "Required");

            // act
            var result = sc.CreateSubject(subject);

            // assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public void DeleteSubject_ValidSubject_ReturnsNoContext()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var deleteResult = sc.DeleteSubject(1);
            var getresult = sc.GetSubjects().Result as OkObjectResult;
            List<SubjectDto> subjects = getresult.Value as List<SubjectDto>;

            // assert
            Assert.IsInstanceOf<NoContentResult>(deleteResult);
            Assert.AreEqual(2, subjects.Count);
        }

        [Test]
        public void DeleteSubject_InValidSubject_ReturnsNotFound()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var deleteResult = sc.DeleteSubject(4);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(deleteResult);
            
        }

        [Test]
        public void UpdateSubject_ValidSubject_ReturnsNoContent()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectDto subject = new SubjectDto
            {
                firstName = "Mark",
                lastName = "Garsden",
                dateOfBirth = new DateTime(1980, 2, 11),
                titleId = 1
            };

            // act
            var result = sc.UpdateSubject(1, subject);

            // assert
            Assert.IsInstanceOf<NoContentResult>(result);

        }

        [Test]
        public void UpdateSubject_InValidSubject_ReturnsNotFound()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectDto subject = new SubjectDto
            {
                firstName = "Mark",
                lastName = "Garsden",
                dateOfBirth = new DateTime(1980, 2, 11),
                titleId = 1
            };

            // act
            var result = sc.UpdateSubject(4, subject);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(result);

        }

        [Test]
        public void UpdateSubject_InValidSubjectData_ReturnsBadRequest()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            SubjectDto subject = new SubjectDto
            {
                firstName = "",
                lastName = "Garsden",
                dateOfBirth = new DateTime(1980, 2, 11),
                titleId = 1
            };
            sc.ModelState.AddModelError("firstName", "Required");

            // act
            var result = sc.UpdateSubject(1, subject);

            // assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);

        }
    }
}