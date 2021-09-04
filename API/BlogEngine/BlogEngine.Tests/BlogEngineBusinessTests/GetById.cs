// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Tests.BlogEngineBusinessTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BlogEngine.Business;
    using BlogEngine.Business.Interfaces;
    using BlogEngine.Entities.Model;
    using BlogEngine.Tests.Repository;

    /// <summary>
    /// This class is for testing the GetByID function.
    /// </summary>
    [TestClass]
    public class GetById
    {
        /// <summary>
        /// This stage is when the Id is null.
        /// </summary>
        [TestMethod]
        public void WhenIdIsNull()
        {

            // Arrange
            int ExpectedResponse = 400;
            BlogEngineRepositoryTest objectRepositoryTest = new BlogEngineRepositoryTest();
            EntityPrimaryKey objectGetById = null;
            
            // Act
            BlogEngineBusiness objectBusiness = new BlogEngineBusiness(objectRepositoryTest);
            EntityResponse<BlogEngine> ResponseService = objectBusiness.GetById(objectGetById);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
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
            EntityResponse<BlogEngine> ResponseService = objectBusiness.GetById(objectGetById);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
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
            EntityPrimaryKey objectGetById = new EntityPrimaryKey()
            {
                Id = 1
            };
            // Act
            BlogEngineBusiness objectBusiness = new BlogEngineBusiness(objectRepositoryTest);
            EntityResponse<BlogEngine> ResponseService = objectBusiness.GetById(objectGetById);

            // Assert
            Assert.AreEqual(ExpectedResponse, ResponseService.ResponseCode);
        }
    }
}
