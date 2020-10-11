using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using SubjectOrderDetails.Controllers;
using SubjectOrderDetails.Models;
using System;
using System.Collections.Generic;

namespace SubjectOrderDetailsTests
{
    class TitlesControllerTest
    {
        [Test]
        public void GetTitles_ReturnsOkResult()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            TitlesController tc = new TitlesController(fake);

            // act
            var result = tc.GetTitles();

            // assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public void GetTitles_ReturnsTitleDtoList()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            TitlesController tc = new TitlesController(fake);

            // act
            var result = tc.GetTitles().Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<List<TitleDto>>(result.Value);
        }


        [Test]
        public void GetTitles_ReturnsAllItems()
        {
            // arrange
            FakeSubjectOrderRepository fake = new FakeSubjectOrderRepository();
            TitlesController tc = new TitlesController(fake);

            // act
            var result = tc.GetTitles().Result as OkObjectResult;
            List<TitleDto> titles = result.Value as List<TitleDto>;

            // assert
            Assert.AreEqual(5, titles.Count);
        }
    }
}
