using Xunit;
using System;
using Moq;
using KNet.API.Repositories;
using System.Threading.Tasks;
using KNet.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KNet.API.Controllers.V1.Tests
{
    public class AdvertControllerTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(3)]
        public async Task GetAdvertByGuid_Status200OKIsType_ReturnedIdEqualsInput(int adNumber)
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            Guid advertId = mockedAdverts[adNumber].Id;
            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup(repo => repo.GetAdvertById(advertId))
                .Returns(Task.FromResult(mockedAdverts[adNumber]));
            var controller = new AdvertController(mockRepo.Object);

            //Act
            var result = await controller.Get(advertId);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Advert>(okResult.Value);
            Assert.Equal(advertId, returnValue.Id);
        }

        [Fact]
        public async Task GetAllAdverts_Status200OKIsType_ReturnedIdEqualsInput()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup(repo => repo.GetAllAdverts())
                .Returns(Task.FromResult(mockedAdverts));
            var controller = new AdvertController(mockRepo.Object);

            //Act
            var result = await controller.List();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Advert>>(okResult.Value);
            Assert.True(returnValue.Equals(mockedAdverts));
            Assert.Equal(returnValue.Count, mockedAdverts.Count);
        }

        private IList<Advert> GetTestSession()
        {
            var session = new Advert()
            {
                Id = Guid.NewGuid()
            };

            return new List<Advert>
            {
                new Advert
                {
                    Id = Guid.NewGuid()
                },
                new Advert
                {
                    Id = Guid.NewGuid()
                },
                new Advert
                {
                    Id = Guid.NewGuid()
                },
                new Advert
                {
                    Id = Guid.NewGuid()
                },
                new Advert
                {
                    Id = Guid.NewGuid()
                },
                new Advert
                {
                    Id = Guid.NewGuid()
                }
            };
        }
    }
}