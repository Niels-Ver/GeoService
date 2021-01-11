using DomainLayer.DomainLayer;
using DomainLayer.Repositories;
using GeoService;
using GeoService.ApiBaseClass;
using GeoService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GeoServiceApiTest
{
    public class ContinentControllerTest
    {
        private readonly Mock<IContinentRepository> mockRepo;
        private readonly ContinentController continentController;

        public ContinentControllerTest()
        {
            mockRepo = new Mock<IContinentRepository>();
            continentController = new ContinentController(mockRepo.Object);
        }

        [Fact]
        public void GET_UnknownID_ReturnsNotFound()
        {
            mockRepo.Setup(repo => repo.GetContinent(2)).Throws(new ApiException("Continent doesn't exist!"));
            var result = continentController.Get(2);
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
        [Fact]
        public void GET_CorrectID_ReturnsOKResult()
        {
            mockRepo.Setup(repo => repo.GetContinent(2)).Returns(new Continent("Alaska"));
            var result = continentController.Get(2);
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GET_CorrectID_ReturnsCountry()
        {
            Continent continent = new Continent("Alaska");
            mockRepo.Setup(repo => repo.GetContinent(2)).Returns(continent);
            var result = continentController.Get(2).Result as OkObjectResult;

            Assert.IsType<ApiContinent>(result.Value);
            Assert.Equal(continent.Name, (result.Value as ApiContinent).Name);
        }

        [Fact]
        public void POST_ValidObject_ReturnsCreatedAtAction()
        {
            Continent continent = new Continent("Alaska");
            var response = continentController.Post(continent);
            Assert.IsType<CreatedAtActionResult>(response.Result);
        }

        [Fact]
        public void POST_ValidObject_ReturnsCorrectItem()
        {
            Continent continent = new Continent("Alaska");
            var response = continentController.Post(continent).Result as CreatedAtActionResult;
            var item = response.Value as ApiContinent;

            Assert.IsType<ApiContinent>(item);
            Assert.Equal(continent.Name, item.Name);
        }

    }
}
