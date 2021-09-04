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

    [TestClass]

    public class InsertTest
    {

        [TestMethod]
        public void WhenTheFieldIsRequiredIsNull()
        {
            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngineInsertRequest BlogEnginetest = new BlogEngineInsertRequest();
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated();
            BlogEnginetest = null;
            usersAuthenticated = null;
            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Insert(BlogEnginetest, usersAuthenticated);

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
            BlogEngineInsertRequest BlogEnginetest = new BlogEngineInsertRequest()
            {                
                Name = "c",
                Description = "c",
                ProfileId = 1,
                BehaviourTypeId = 1,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now               
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };
            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Insert(BlogEnginetest, usersAuthenticated);
            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]
        public void WhenTheResponseIsNotNull()
        {
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            // Act
            BlogEngineInsertRequest BlogEnginetest = new BlogEngineInsertRequest()
            {
                Name = "c",
                Description = "c",
                ProfileId = 1,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };
            EntityResponse<BlogEngine> ResponseService;
            ResponseService = new EntityResponse<BlogEngine>
            {
                ResponseCode = 200,
                RowsAffected = 1,
                ResponseMessage = ResourceMessage.repositoryResponseMessageOk

            };
            var mockPrueba = new Mock<IBlogEngineRepository>();
            mockPrueba.Setup(response => response.Insert(BlogEnginetest, usersAuthenticated)).Returns(ResponseService);
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
            BlogEngineInsertRequest BlogEnginetest = new BlogEngineInsertRequest()
            {
                Name = "c",
                Description = "c",
                ProfileId = 1,
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
            };
            UsersAuthenticated usersAuthenticated = new UsersAuthenticated()
            {
                email = "test@test.com"
            };
            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.Insert(BlogEnginetest, usersAuthenticated);
            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }
    }

}
