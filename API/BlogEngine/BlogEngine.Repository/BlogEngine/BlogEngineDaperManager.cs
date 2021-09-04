// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Repository
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using BlogEngine.Entities.Model;
    using System.Collections.ObjectModel;
    using System.Linq;  

    /// <summary>
    /// Daper manager connection class.
    /// </summary>
    public sealed class BlogEngineDaperManager : DapperManager<BlogEngine>
    {
        /// <summary>
        /// EntityGetResponse<BlogEngine> object.
        /// </summary>
        private EntityGetResponse<BlogEngine> objectGetResponse;

        /// <summary>
        /// In this constructor, the configuration is initialized
        /// </summary>
        /// <param name="config"></param>
        public BlogEngineDaperManager(IConfiguration config)
            : base(config)
        {
            objectGetResponse = new EntityGetResponse<BlogEngine>();
        }

        /// <summary>
        /// This method is responsible for getting all the items from the database.
        /// </summary>
        /// <returns></returns>
        public Collection<BlogEngine> GetList()
        {
            string storedProcedured = "EXEC Blogs_GetList";
            var response = this.GetList(storedProcedured);
            return response;
        }

        /// <summary>
        /// This method is responsible for getting an item from the database by its Id.
        /// </summary>
        /// <param name="objectGetbyId"></param>
        /// <returns></returns>
        public BlogEngine GetById(EntityPrimaryKey objectGetbyId)
        {
            string storedProcedured = "EXEC Blogs_GetById @Id";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", objectGetbyId.Id);
            var QueryResponse = this.GetById(storedProcedured, parameter);
            return QueryResponse;
        }

        /// <summary>
        /// This method is responsible for deleting an item from the database.
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns></returns>
        public int Delete(EntityPrimaryKey objectDelete)
        {
            string storedProcedured = "EXEC Blogs_Delete @Id";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@Id", objectDelete.Id);
            var RowsAffected = this.Delete(storedProcedured, parameter);
            Dispose();
            return RowsAffected;
        }

        /// <summary>
        /// This method is responsible for making the insertion of an item to the database.
        /// </summary>
        /// <param name="objectInsert"></param>
        /// <returns></returns>
        public string Insert(BlogEngineInsertRequest objectInsert, UsersAuthenticated userAuthenticated)
        {
            EntityInsertResponse IdTransactionCode = new EntityInsertResponse();
            if (objectInsert != null)
            {
                string storedProcedured = "EXEC Blogs_Insert "

                + "@Title,"
                + "@Description,"
                + "@Owner,"
                + "@CreatedAt,"
                + "@ModifiedAt,"
                + "@CreatedBy,"
                + "@ModifiedBy,";
                storedProcedured = storedProcedured.Remove(storedProcedured.Length - 1);
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@Title", objectInsert.Title);
                parameter.Add("@Description", objectInsert.Description);
                parameter.Add("@Owner", objectInsert.Owner);             
                parameter.Add("@CreatedAt", objectInsert.CreatedAt);
                parameter.Add("@ModifiedAt", objectInsert.ModifiedAt);
                parameter.Add("@CreatedBy", userAuthenticated.email);
                parameter.Add("@ModifiedBy", userAuthenticated.email);
                IdTransactionCode = this.Insert(storedProcedured, parameter);
            }
            return IdTransactionCode.IdTransactionCode;
        }

        /// <summary>
        /// This method is responsible for updating an item from the database.
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns></returns>
        public int Update(BlogEngine objectUpdate, UsersAuthenticated userAuthenticated)
        {
            int rowsAffected = 0;
            if (objectUpdate != null)
            {
                string storedProcedured = "EXEC Blogs_Update "
                           + "@Id,"
                           + "@Title,"
                           + "@Owner, "
                           + "@Description,"                           
                           + "@ModifiedBy,";
                storedProcedured = storedProcedured.Remove(storedProcedured.Length - 1);
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", objectUpdate.Id);
                parameter.Add("@Title", objectUpdate.Title);
                parameter.Add("@Owner", objectUpdate.Owner);
                parameter.Add("@Description", objectUpdate.Description);               
                parameter.Add("@ModifiedBy", userAuthenticated.email);
                rowsAffected = this.Update(storedProcedured, parameter);
            }
            return rowsAffected;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity depending on the parameters sent.
        /// </summary>
        /// <param name="objectGetListByParams"></param>
        /// <returns></returns>
        public EntityGetResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams, UsersAuthenticated userAuthenticated)
        {
            if (objectGetListByParams != null)
            {
                string storedProcedured = "EXEC Blogs_GetListByParams "
                    + "@Id,"
                    + "@Title,"
                    + "@Description,"
                    + "@Owner,"                   
                    + "@CreatedAt,"
                    + "@ModifiedAt,"
                    + "@CreatedBy,"
                    + "@ModifiedBy,"
                    + "@OrderBy,"
                    + "@Ascendent, "
                    + "@PageNumber,"
                    + "@ResultsPerPage";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", objectGetListByParams.Id);
                parameter.Add("@Title", objectGetListByParams.Title);
                parameter.Add("@Description", objectGetListByParams.Description);
                parameter.Add("@Owner", objectGetListByParams.Owner);
                parameter.Add("@CreatedAt", objectGetListByParams.CreatedAt);
                parameter.Add("@ModifiedAt", objectGetListByParams.ModifiedAt);
                parameter.Add("@CreatedBy", userAuthenticated.email);
                parameter.Add("@ModifiedBy", userAuthenticated.email);
                parameter.Add("@OrderBy", objectGetListByParams.OrderBy);
                parameter.Add("@Ascendent", objectGetListByParams.Ascendent);
                parameter.Add("@PageNumber", objectGetListByParams.PageNumber);
                parameter.Add("@ResultsPerPage", objectGetListByParams.ResultsPerPage);
                objectGetResponse = this.GetListByParams(storedProcedured, parameter);
            }
            return objectGetResponse;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity with pagination.
        /// </summary>
        /// <param name="objectGetListOrdered"></param>
        /// <returns></returns>
        public EntityGetResponse<BlogEngine> GetListOrdered(EntityGetListOrdered objectGetListOrdered)
        {
            if (objectGetListOrdered != null)
            {
                string storedProcedured = "EXEC gvdp.BlogEngine_GetListOrdered @OrderBy, " +
                    "@Ascendent, @PageNumber, @ResultsPerPage";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@OrderBy", objectGetListOrdered.OrderBy);
                parameter.Add("@Ascendent", objectGetListOrdered.Ascendent);
                parameter.Add("@PageNumber", objectGetListOrdered.PageNumber);
                parameter.Add("@ResultsPerPage", objectGetListOrdered.ResultsPerPage);
                objectGetResponse = this.GetListByParams(storedProcedured, parameter);
            }
            return objectGetResponse;
        }
    }
}
