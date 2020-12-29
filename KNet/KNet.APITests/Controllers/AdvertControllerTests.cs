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
        public async Task GetAdvertByGuid_Status200OKIsType_ReturnedIdEqualsInputId(int adNumber)
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
            var returnValue = Assert.IsType<AdvertModel>(okResult.Value);
            Assert.Equal(advertId, returnValue.Id);
        }

        [Fact]
        public async Task GetAllAdverts_Status200OKIsType_ReturnedListEqualsOriginalListLength()
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
            var returnValue = Assert.IsType<List<AdvertModel>>(okResult.Value);
            Assert.True(returnValue.Equals(mockedAdverts));
            Assert.Equal(returnValue.Count, mockedAdverts.Count);
        }

        [Fact]
        public async Task PostAdvert_Status200OKIsType_PostReturnEqualsInput()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockedAdvert = new CreateAdvertModel
            {
                Content = "Some content"
            };

            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup
            (
                repo => repo.Add(mockedAdvert))
                .Returns(Task.FromResult(mockedAdvert)
            );
            var controller = new AdvertController(mockRepo.Object);

            //Act
            var postResult = await controller.Post(mockedAdvert);

            //Assert
            var postOkResult = Assert.IsType<OkObjectResult>(postResult);
            var postReturnValue = Assert.IsType<AdvertModel>(postOkResult.Value);
            Assert.Equal(mockedAdvert.Content, postReturnValue.Content);
        }

        [Fact]
        public async Task PutAdvert_Status200OKIsType_ControllerPutReturnsOkWhenIdFound()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockedUpdateAdvert = new UpdateAdvertModel
            {
                Id = mockedAdverts[0].Id,
                Content = "Updated"
            };
            var mockedAdvert = new AdvertModel
            {
                Id = mockedAdverts[0].Id,
                Content = "Updated"
            };

            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup
            (
                repo => repo.Update(mockedUpdateAdvert))
                .Returns(Task.FromResult(mockedUpdateAdvert)
            );
            mockRepo.Setup
            (
                repo => repo.GetAdvertById(mockedUpdateAdvert.Id))
                .Returns(Task.FromResult(mockedAdvert)
            );

            var controller = new AdvertController(mockRepo.Object);

            //Act
            var putResult = await controller.Put(mockedUpdateAdvert);

            //Assert
            Assert.IsType<OkResult>(putResult);
        }

        [Fact]
        public async Task DeleteAdvert_Status200OKIsType_ControllerDeleteReturnsOkWhenIdFound()
        {
            //Arrange
            var mockedAdverts = GetTestSession();
            var mockedAdvert = new AdvertModel
            {
                Id = mockedAdverts[0].Id
            };

            var mockRepo = new Mock<IAdvertRepository>();
            mockRepo.Setup
            (
                repo => repo.Delete(mockedAdvert))
                .Returns(Task.FromResult(mockedAdvert)
            );
            mockRepo.Setup
            (
                repo => repo.GetAdvertById(mockedAdvert.Id))
                .Returns(Task.FromResult(mockedAdvert)
            );

            var controller = new AdvertController(mockRepo.Object);

            //Act
            var deleteResult = await controller.Delete(mockedAdvert.Id);

            //Assert
            Assert.IsType<OkResult>(deleteResult);
        }

        private IList<AdvertModel> GetTestSession()
        {
            return new List<AdvertModel>
            {
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                },
                new AdvertModel
                {
                    Id = Guid.NewGuid(),
                    Content = "Not Updated"
                }
            };
        }
    }
}