
// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Tests.BlogEngineBusinessTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using BlogEngine.Business;
    using BlogEngine.Business.Interfaces;
    using BlogEngine.Entities.Model;
    using BlogEngine.Repository.Interfaces;
    using BlogEngine.Tests.Repository;
    using BlogEngine.Utils.Resources;

    // using Moq;
    [TestClass]
    public class UpdateTest
    {
        [TestMethod]
        public void WhenPrimaryKeyIsNotValid()
        {
            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngine BlogEnginetest = new BlogEngine()
            {
                Id = 0
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Update(BlogEnginetest, usersAuthenticated);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]

        public void WhenTheFieldIsRequiredIsNull()
        {
            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngine BlogEnginetest = new BlogEngine()
            {
                Id = 0,
                Title = null,
                Description = null,               
                CreatedAt = System.DateTime.Now,
                ModifiedAt = System.DateTime.Now,
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Update(BlogEnginetest, usersAuthenticated);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]

        public void WhenAllParametersIsValid()
        {

            // Arrange

            int ExpectedResponse = 200;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngine BlogEnginetest = new BlogEngine()
            {
                Id = 1,
                Title = "c",
                Description = "c",
                Owner = "User",               
                CreatedAt = System.DateTime.Now,
                ModifiedAt = System.DateTime.Now,
                CreatedBy = "user@user.com",
                ModifiedBy = "user@user.com"
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com",
                Name = "TestUser"
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Update(BlogEnginetest, usersAuthenticated);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]
        public void WhenTheResponseIsNotNull()
        {
            // Act
            BlogEngine BlogEnginetest = new BlogEngine()
            {
                Id = 1,
                Title = "c",
                Description = "c",                
                CreatedAt = System.DateTime.Now,
                ModifiedAt = System.DateTime.Now,
            };
            EntityResponse<BlogEngine> ResponseService;
            ResponseService = new EntityResponse<BlogEngine>
            {
                ResponseCode = 200,
                RowsAffected = 1,
                ResponseMessage = ResourceMessage.repositoryResponseMessageOk
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };
            var mockPrueba = new Mock<IBlogEngineRepository>();
            mockPrueba.Setup(response => response.Update(BlogEnginetest, usersAuthenticated)).Returns(ResponseService);
            Assert.AreEqual(1, ResponseService.RowsAffected);
        }


        /// <summary>
        /// This stage is when the Respone is valid but an exception was thrown.
        /// </summary>
        [TestMethod]
        public void WhenAnExceptionsIsThrown()
        {

            // Arrange

            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest(true);
            // Act
            BlogEngine BlogEnginetest = new BlogEngine()
            {
                Id = 1,
                Title = "c",
                Description = "c",                
                CreatedAt = System.DateTime.Now,
                ModifiedAt = System.DateTime.Now,
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Update(BlogEnginetest, usersAuthenticated);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }
    }

}
