using Xunit;
using System;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using KNet.API.Repositories;
using KNet.API.Controllers.V1;
using KNet.API.Models;

namespace KNet.API.Controllers.Tests
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
        public async Task GetAllAdverts_Status200OKIsType_ReturnedListEqualsOriginalList()
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

        [Fact]
        public async Task PostAdvert_Status200OKIsType_ReturnedListContainsPostedAdvert()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockedAdvert = new CreateAdvertModel
            {
            };

            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup
            (
                repo => repo.GetAllAdverts())
                .Returns(Task.FromResult(mockedAdverts)
            );
            mockRepo.Setup
            (
                repo => repo.Add(mockedAdvert))
                .Returns(Task.FromResult(mockedAdvert)
            );
            var controller = new AdvertController(mockRepo.Object);

            //Act
            var postResult = await controller.Post(mockedAdvert);
            var getResult = await controller.List();

            //Assert
            var postOkResult = Assert.IsType<OkObjectResult>(postResult);
            var postReturnValue = Assert.IsType<Advert>(postOkResult.Value);
            var getOkResult = Assert.IsType<OkObjectResult>(getResult);
            var getReturnValue = Assert.IsType<List<Advert>>(getOkResult.Value);
            Assert.True(getReturnValue.Exists(a => a.Id == postReturnValue.Id));
        }

        [Fact]
        public async Task PutAdvert_Status200OKIsType_ModificationOfAdvertInListIsVerified()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockedAdvert = new Advert
            {
                Id = mockedAdverts[0].Id,
                Content = "Updated"
            };

            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup
            (
                repo => repo.Update(mockedAdvert))
                .Returns(Task.FromResult(mockedAdvert)
            );
            mockRepo.Setup
            (
                repo => repo.GetAdvertById(mockedAdvert.Id))
                .Returns(Task.FromResult(mockedAdvert)
            );

            var controller = new AdvertController(mockRepo.Object);

            //Act
            var putResult = await controller.Put(mockedAdvert);
            var getResult = await controller.Get(mockedAdvert.Id);

            //Assert
            Assert.IsType<OkResult>(putResult);
            var okResult = Assert.IsType<OkObjectResult>(getResult);
            var returnValue = Assert.IsType<Advert>(okResult.Value);
            Assert.Equal(returnValue.Content, mockedAdvert.Content);
        }

        private IList<Advert> GetTestSession()
        {
            return new List<Advert>
            {
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new Advert
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                }
            };
        }
    }
}