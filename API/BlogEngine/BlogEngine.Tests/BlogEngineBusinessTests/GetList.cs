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
    using System.Collections.ObjectModel;

    [TestClass]

    public class GetList
    {
        [TestMethod]
        public void WhenTheResponseIsNotNull()
        {
            Collection<BlogEngine> objectList = new Collection<BlogEngine>();
            // Act
            EntityResponse<BlogEngine> ResponseService;

            for (int i = 1; i < 6; i++)
            {
                BlogEngine BlogEnginetest = new BlogEngine()
                {
                    Id = i,
                    Title = "word" + i.ToString(),
                    Description = "word" + i.ToString(),                  
                    CreatedAt = System.DateTime.Now,
                    ModifiedAt = System.DateTime.Now,
                };
                objectList.Add(BlogEnginetest);
            }
            ResponseService = new EntityResponse<BlogEngine>
            {
                ResponseCode = 200,
                RowsAffected = 5,
                ResultData = objectList,
                ResponseMessage = ResourceMessage.repositoryResponseMessageOk

            };

            var mockPrueba = new Mock<IBlogEngineRepository>();
            mockPrueba.Setup(response => response.GetList()).Returns(ResponseService);
            Assert.IsNotNull(ResponseService.ResultData);
        }

        /// <summary>
        /// This stage is when the Respone is valid.
        /// </summary>
        [TestMethod]
        public void WhenTheResponseIsValid()
        {

            // Arrange
            int ExpectedResponse = 200;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            EntityPrimaryKey objectGetById = new EntityPrimaryKey()
            {
                Id = 1
            };
            
            // Act
            BlogEngineBusiness objectBusiness = new BlogEngineBusiness(objectRepositoryTest);
            EntityResponse<BlogEngine> ResponseService = objectBusiness.GetList();

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        /// <summary>
        /// This stage is when the Respone is valid.
        /// </summary>
        [TestMethod]
        public void WhenAnExceptionsIsThrown()
        {

            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest(true);
            EntityPrimaryKey objectGetById = new EntityPrimaryKey()
            {
                Id = 1
            };
            // Act
            BlogEngineBusiness objectBusiness = new BlogEngineBusiness(objectRepositoryTest);
            EntityResponse<BlogEngine> ResponseService = objectBusiness.GetList();

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }
    }

}
