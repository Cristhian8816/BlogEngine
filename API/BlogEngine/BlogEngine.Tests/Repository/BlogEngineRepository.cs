// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Tests.Repository
{
    using BlogEngine.Entities.Model;
    using BlogEngine.Repository.Interfaces;
    using BlogEngine.Utils.Resources;

    /// <summary>
    /// This class is responsible for the persistence test of the microservice project.
    /// </summary>
    public class BlogEngineRepositoryTest : IBlogEngineRepository
    {
        /// <summary>
        /// Response
        /// </summary>
        private EntityResponse<BlogEngine> responseMethod;

        /// <summary>
        /// If methods need to throw an exception
        /// </summary>
        private readonly bool throwException;

        /// <summary>
        /// In the constructor, the instances that will be used in the methods are initialized.
        /// </summary>
        public BlogEngineRepositoryTest(bool exception = false)
        {
            throwException = exception;
            responseMethod = new EntityResponse<BlogEngine>();
        }

        /// <summary>
        /// This method is responsible for getting all the items from the database
        /// </summary>
        /// <returns>BlogEngineResponse</returns>
        public EntityResponse<BlogEngine> GetList()
        {

            return GetSuccessResponse();
        }

        /// <summary>
        /// This method is responsible for getting an item from the database by its Id.
        /// </summary>
        /// <param name="objectGetById"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetById(EntityPrimaryKey objectGetById)
        {
            return GetSuccessResponse();
        }

        /// <summary>
        /// This method is responsible for deleting an item from the database.
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Delete(EntityPrimaryKey objectDelete)
        {
            return GetSuccessResponse();
        }

        /// <summary>
        /// This method is responsible for making the insertion of an item to the database.
        /// </summary>
        /// <param name="objectInsert">This object of type "BlogEngine" has the necessary
        /// attributes that the stored procedure requires to perform its insertion function.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Insert(BlogEngineInsertRequest objectInsert,  UsersAuthenticated usersAuthenticated)
        {
            return GetSuccessResponse();
        }

        /// <summary>
        /// This method is responsible for updating an item from the database.
        /// </summary>
        /// <param name="ObjectUpdate">This object of type "BlogEngine" has the necessary
        /// attributes that the stored procedure requires to perform its updating function.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Update(Entities.Model.BlogEngine objectUpdate, UsersAuthenticated usersAuthenticated)
        {
            return GetSuccessResponse();
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity depending on the parameters sent.
        /// </summary>
        /// <param name="objectGetListByParams"></param>
        /// <returns>BlogEngineResponse</returns>
        public EntityResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams)
        {
            return GetSuccessResponse();

        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity with pagination.
        /// </summary>
        /// <param name="objectGetListOrdered"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetListOrdered(EntityGetListOrdered objectGetListOrdered)
        {
            return GetSuccessResponse();
        }

        /// <summary>
        /// Get from GetByFK_BlogEngine_Profiles.
        /// </summary>
        /// <param name="ProfileId"></param> 
        /// <returns></returns>
        public EntityResponse<BlogEngine> GetByFK_BlogEngine_Profiles(int profileId)
        {
            return profileId > 0 ? GetSuccessResponse() : GetWrongResponse("Profile Id is not valid");
        }

        /// <summary>
        /// Get from GetByFK_BlogEngine_BehaviourTypes.
        /// </summary>
        /// <param name="BehaviourTypeId"></param> 
        /// <returns></returns>
        public EntityResponse<BlogEngine> GetByFK_BlogEngine_BehaviourTypes(int BehaviourTypeId)
        {
            return BehaviourTypeId > 0 ? GetSuccessResponse() : GetWrongResponse("BehaviourTypeId Id is not valid"); 
        }


        private EntityResponse<BlogEngine> GetSuccessResponse()
        {
            ValidateException();
            responseMethod.RowsAffected = 0;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = "200";
            responseMethod.ResultData = null;
            return responseMethod;
        }

        private EntityResponse<BlogEngine> GetWrongResponse(string responseMessage)
        {
            responseMethod.RowsAffected = 0;
            responseMethod.ResponseCode = 400;
            responseMethod.ResponseMessage = responseMessage;
            responseMethod.IdTransactionCode = null;
            responseMethod.ResultData = null;
            return responseMethod;
        }

        private void ValidateException()
        {
            if (throwException)
            {
                throw new System.Exception("Unit test exception");
            }
        }
    }
}
