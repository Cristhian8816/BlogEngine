
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

    public class GetListByParamsTest
    {
        [TestMethod]
        public void WhenOrderByIsASpecialCharacter()
        {

            // Arrange

            int ExpectedResponse = 200;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = "1./",
                PageNumber = 1,
                ResultsPerPage = 1
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]

        public void WhenPageNumberAndResultsPerPageIsInvalidThenReturnError()
        {

            // Arrange

            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = "1",
                PageNumber = -1,
                Ascendent = true,
                ResultsPerPage = 0
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]

        public void WhenOrderByIsNull()
        {

            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = null,
                PageNumber = -1,
                Ascendent = true,
                ResultsPerPage = 0
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]

        public void WhenTheParameterStringIsCharacterSpecial()
        {
            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            
            // Act
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                Title = "word/*",
                Description = "word/*",
                CreatedAt = System.DateTime.Now,
                UpdatedAt = System.DateTime.Now,
                OrderBy = "1/*",
                PageNumber = -1,
                Ascendent = true,
                ResultsPerPage = 0
            };
            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

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
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = "2",
                PageNumber = 1,
                Ascendent = true,
                ResultsPerPage = 2
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }

        [TestMethod]
        public void WhenTheResponseIsNotNull()
        {
            Collection<BlogEngine> objectList = new Collection<BlogEngine>();

            // Act
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = "2",
                PageNumber = 1,
                Ascendent = true,
                ResultsPerPage = 2
            };

            EntityResponse<BlogEngine> ResponseService;
            for (int i = 1; i < 6; i++)
            {
                BlogEngine BlogEnginetest = new BlogEngine()
                {
                    Id = i,
                    Title = "c" + i.ToString(),
                    Description = "c" + i.ToString(),                  
                    CreatedAt = System.DateTime.Now,
                    UpdatedAt = System.DateTime.Now,
                };
                objectList.Add(BlogEnginetest);
            }
            var mockPrueba = new Mock<IBlogEngineRepository>();
            mockPrueba.Setup(response => response.GetListByParams(BlogEngineGetListByParamstest)).Returns(ResponseService = new EntityResponse<BlogEngine>
            {
                ResponseCode = 200,
                RowsAffected = 5,
                ResultData = objectList,
                ResponseMessage = ResourceMessage.repositoryResponseMessageOk
            });
            Assert.IsNotNull(ResponseService.ResultData);
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
            BlogEngineGetListByParams BlogEngineGetListByParamstest = new BlogEngineGetListByParams()
            {
                OrderBy = "1./",
                PageNumber = 1,
                ResultsPerPage = 1
            };

            EntityResponse<BlogEngine> ResponseService;
            BlogEngineBusiness objectTestBusiness = new BlogEngineBusiness(objectRepositoryTest);
            ResponseService = objectTestBusiness.GetListByParams(BlogEngineGetListByParamstest);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }
    }

}
