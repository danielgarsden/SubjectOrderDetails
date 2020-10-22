using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SubjectOrderDetails.Controllers;
using SubjectOrderDetails.Models;
using System;
using System.Collections.Generic;

namespace SubjectOrderDetailsTests
{
    public class SubjectControllerTest
    {
   
        [Test]
        public void GetSubjects_ReturnsOkResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var result = sc.GetSubjects(null);

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
            var result = sc.GetSubjects(null).Result as OkObjectResult;

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
            var result = sc.GetSubjects(null).Result as OkObjectResult;
            List<SubjectDto> subjects =  result.Value as List<SubjectDto>;

            // assert
            Assert.AreEqual(5, subjects.Count);
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
            var result = sc.GetSubject(6);

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
                FirstName = "Zita",
                LastName = "Garsden Kabok",
                DateOfBirth = new DateTime(1980, 05, 03),
                TitleId = 2
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
                FirstName = "Zita",
                LastName = "Garsden Kabok",
                DateOfBirth = new DateTime(1980, 05, 03),
                TitleId = 2
            };

            // act
            CreatedAtRouteResult result = sc.CreateSubject(subject) as CreatedAtRouteResult;

            // assert
            Assert.IsInstanceOf<SubjectDto>(result.Value);
            Assert.AreEqual("GetSubject", result.RouteName);

            SubjectDto subjectReturned = result.Value as SubjectDto;

            Assert.AreEqual(6, subjectReturned.subjectId);
            Assert.AreEqual("Zita", subjectReturned.firstName);
            Assert.AreEqual("Garsden Kabok", subjectReturned.lastName);
            Assert.AreEqual("03/05/1980", subject.DateOfBirth.ToString("d"));
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
                LastName = "Garsden Kabok",
                DateOfBirth = new DateTime(1980, 05, 03),
                TitleId = 2
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
            var getresult = sc.GetSubjects(null).Result as OkObjectResult;
            List<SubjectDto> subjects = getresult.Value as List<SubjectDto>;

            // assert
            Assert.IsInstanceOf<NoContentResult>(deleteResult);
            Assert.AreEqual(4, subjects.Count);
        }

        [Test]
        public void DeleteSubject_InValidSubject_ReturnsNotFound()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            SubjectsController sc = new SubjectsController(fake);

            // act
            var deleteResult = sc.DeleteSubject(6);

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
            var updateResult = sc.UpdateSubject(1, subject);
            var getResult = sc.GetSubject(1).Result as OkObjectResult;
            SubjectDto subjectReturned = getResult.Value as SubjectDto;

            // assert
            Assert.IsInstanceOf<NoContentResult>(updateResult);
            Assert.AreEqual("Mark", subjectReturned.firstName);
            Assert.AreEqual("Garsden", subjectReturned.lastName);
            Assert.AreEqual("11/02/1980", subject.dateOfBirth.ToString("d"));
            Assert.AreEqual(1, subjectReturned.titleId);

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
            var result = sc.UpdateSubject(6, subject);

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