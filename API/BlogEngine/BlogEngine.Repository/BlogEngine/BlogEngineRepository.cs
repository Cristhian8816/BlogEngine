// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Repository
{
    using Microsoft.Extensions.Configuration;
    using BlogEngine.Entities.Model;
    using BlogEngine.Repository.Interfaces;
    using BlogEngine.Utils.Resources;
    using System.Collections.ObjectModel;

    /// <summary>
    /// This class is responsible for the persistence of the microservice project.
    /// </summary>
    public class BlogEngineRepository : IBlogEngineRepository
    {
        /// <summary>
        /// EntityResponse<BlogEngine> responseMethod.
        /// </summary>
        private readonly EntityResponse<BlogEngine> responseMethod;

        /// <summary>
        /// Collection<BlogEngine> object.
        /// </summary>
        private readonly Collection<BlogEngine> objectList;

        /// <summary>
        /// Configuration interface.
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// In the constructor, the instances that will be used in the methods are initialized.
        /// </summary>
        /// <param name="options">This parameter is the one that helps to make the connection 
        /// with the data base.</param>
        public BlogEngineRepository(IConfiguration config)
        {
            _config = config;
            responseMethod = new EntityResponse<BlogEngine>();
            objectList = new Collection<BlogEngine>();
        }

        /// <summary>
        /// This method is responsible for getting all the items from the database.
        /// </summary>
        /// <returns>BlogEngineResponse</returns>
        public EntityResponse<BlogEngine> GetList()
        {
            objectList.Clear();
            using (BlogEngineDaperManager dapper = new(_config))
            {
                var resultList = dapper.GetList();
                if (resultList != null)
                {
                    foreach (var resultObject in resultList)
                    {
                        objectList.Add(resultObject);
                    }
                }

            }
            responseMethod.RowsAffected = objectList.Count;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = null;
            responseMethod.ResultData = objectList;
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for getting an item from the database by its Id.
        /// </summary>
        /// <param name="objectGetById"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetById(EntityPrimaryKey objectGetById)
        {
            objectList.Clear();
            using (BlogEngineDaperManager dapper = new(_config))
            {
                BlogEngine responseObject = dapper.GetById(objectGetById);
                if (responseObject != null)
                {
                    objectList.Add(responseObject);
                }
            }
            responseMethod.RowsAffected = objectList.Count;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = objectGetById.Id.ToString();
            responseMethod.ResultData = objectList;
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for deleting an item from the database.
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Delete(EntityPrimaryKey objectDelete)
        {
            int affectedRows = 0;
            using (BlogEngineDaperManager dapper = new(_config))
            {
                affectedRows = dapper.Delete(objectDelete);
            }
            responseMethod.RowsAffected = affectedRows;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = objectDelete.Id.ToString();
            responseMethod.ResultData = null;
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for making the insertion of an item to the database.
        /// </summary>
        /// <param name="objectInsert">This object of type "BlogEngine" has the necessary
        /// attributes that the stored procedure requires to perform its insertion function.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Insert(BlogEngineInsertRequest objectInsert, UsersAuthenticated userAuthenticated)
        {
            if (objectInsert != null)
            {
                string idTransactionCode;
                using (BlogEngineDaperManager dapper = new(_config))
                {
                    idTransactionCode = dapper.Insert(objectInsert, userAuthenticated);
                }
                responseMethod.RowsAffected = 1;
                responseMethod.ResponseCode = 200;
                responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
                responseMethod.IdTransactionCode = string.IsNullOrEmpty(idTransactionCode) ? default(int).ToString() : idTransactionCode;
                responseMethod.ResultData = null;
            }
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for updating an item from the database.
        /// </summary>
        /// <param name="objectUpdate">This object of type "BlogEngine" has the necessary
        /// attributes that the stored procedure requires to perform its updating function.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Update(BlogEngine objectUpdate, UsersAuthenticated userAuthenticated)
        {
            if (objectUpdate != null)
            {
                int rowsAffected = 0;
                using (BlogEngineDaperManager dapper = new(_config))
                {
                    rowsAffected = dapper.Update(objectUpdate, userAuthenticated);
                }
                responseMethod.ResponseCode = 200;
                responseMethod.RowsAffected = rowsAffected;
                responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
                responseMethod.IdTransactionCode = objectUpdate.Id.ToString();
                responseMethod.ResultData = null;
            }
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity depending on the parameters sent.
        /// </summary>
        /// <param name="objectGetListByParams"></param>
        /// <returns>BlogEngineResponse</returns>
        public EntityResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams, UsersAuthenticated userAuthenticated)
        {
            EntityGetResponse<BlogEngine> result;
            objectList.Clear();
            using (BlogEngineDaperManager dapper = new(_config))
            {
                result = dapper.GetListByParams(objectGetListByParams, userAuthenticated);
                if (result.ResultData != null)
                {
                    foreach (var resultObject in result.ResultData)
                    {
                        objectList.Add(resultObject);
                    }
                }
            }
            responseMethod.RowsAffected = result.TotalResults;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = null;
            responseMethod.ResultData = objectList;
            return responseMethod;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity with pagination.
        /// </summary>
        /// <param name="objectGetListOrdered"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetListOrdered(EntityGetListOrdered objectGetListOrdered)
        {
            EntityGetResponse<BlogEngine> result;
            objectList.Clear();
            using (BlogEngineDaperManager dapper = new(_config))
            {
                result = dapper.GetListOrdered(objectGetListOrdered);
                if (result.ResultData != null)
                {
                    foreach (var resultObject in result.ResultData)
                    {
                        objectList.Add(resultObject);
                    }
                }
            }
            responseMethod.RowsAffected = result.TotalResults;
            responseMethod.ResponseCode = 200;
            responseMethod.ResponseMessage = ResourceMessage.repositoryResponseMessageOk;
            responseMethod.IdTransactionCode = null;
            responseMethod.ResultData = objectList;
            return responseMethod;
        }       
    }
}
