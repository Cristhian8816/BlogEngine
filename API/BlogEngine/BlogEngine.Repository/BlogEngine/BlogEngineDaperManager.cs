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
            string storedProcedured = "EXEC gvdp.BlogEngine_GetList";
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
            string storedProcedured = "EXEC gvdp.BlogEngine_GetById @Id";
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
            string storedProcedured = "EXEC gvdp.BlogEngine_Delete @Id";
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
                string storedProcedured = "EXEC gvdp.BlogEngine_Insert "

                + "@Name,"
                + "@Description,"
                + "@ProfileId,"
                + "@BehaviourTypeId,"
                + "@CreatedAt,"
                + "@UpdatedAt,";
                storedProcedured = storedProcedured.Remove(storedProcedured.Length - 1);
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("@Name", objectInsert.Name);
                parameter.Add("@Description", objectInsert.Description);
                parameter.Add("@ProfileId", objectInsert.ProfileId);
                parameter.Add("@BehaviourTypeId", objectInsert.BehaviourTypeId);
                parameter.Add("@CreatedAt", objectInsert.CreatedAt);
                parameter.Add("@UpdatedAt", objectInsert.UpdatedAt);               
                IdTransactionCode = this.Insert(storedProcedured, parameter);
            }
            return IdTransactionCode.IdTransactionCode;
        }

        /// <summary>
        /// This method is responsible for updating an item from the database.
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns></returns>
        public int Update(BlogEngine objectUpdate)
        {
            int rowsAffected = 0;
            if (objectUpdate != null)
            {
                string storedProcedured = "EXEC gvdp.BlogEngine_Update "
                           + "@Id,"
                           + "@Name,"
                           + "@Description,"
                           + "@ProfileId,"
                           + "@BehaviourTypeId,";
                storedProcedured = storedProcedured.Remove(storedProcedured.Length - 1);
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", objectUpdate.Id);
                parameter.Add("@Name", objectUpdate.Name);
                parameter.Add("@Description", objectUpdate.Description);
                parameter.Add("@ProfileId", objectUpdate.ProfileId);                           
                parameter.Add("@BehaviourTypeId", objectUpdate.BehaviourTypeId);
                rowsAffected = this.Update(storedProcedured, parameter);
            }
            return rowsAffected;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity depending on the parameters sent.
        /// </summary>
        /// <param name="objectGetListByParams"></param>
        /// <returns></returns>
        public EntityGetResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams)
        {
            if (objectGetListByParams != null)
            {
                string storedProcedured = "EXEC gvdp.BlogEngine_GetListByParams "
                    + "@Id,"
                    + "@Name,"
                    + "@Description,"
                    + "@ProfileId,"
                    + "@BehaviourTypeId,"
                    + "@CreatedAt,"
                    + "@UpdatedAt,"                  
                    + "@OrderBy,"
                    + "@Ascendent, "
                    + "@PageNumber,"
                    + "@ResultsPerPage";
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", objectGetListByParams.Id);
                parameter.Add("@Name", objectGetListByParams.Name);
                parameter.Add("@Description", objectGetListByParams.Description);
                parameter.Add("@ProfileId", objectGetListByParams.ProfileId);
                parameter.Add("@BehaviourTypeId", objectGetListByParams.BehaviourTypeId);
                parameter.Add("@CreatedAt", objectGetListByParams.CreatedAt);
                parameter.Add("@UpdatedAt", objectGetListByParams.UpdatedAt);               
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

        /// <summary>
        /// Get from GetByFK_BlogEngine_Profiles.
        /// </summary>
        /// <param name="ProfileId"></param> 
        /// <returns>EntityGetResponse<BlogEngine> Object.</returns>
        public EntityGetResponse<BlogEngine> GetByFK_BlogEngine_Profiles(int ProfileId)
        {
            string storedProcedured = "EXEC gvdp.BlogEngine_GetByFK_BlogEngine_Profiles @ProfileId";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@ProfileId", ProfileId);
            objectGetResponse = this.GetListByParams(storedProcedured, parameter);
            return objectGetResponse;
        }

        /// <summary>
        /// Get from GetByFK_BlogEngine_Profiles.
        /// </summary>
        /// <param name="BehaviourTypeId"></param> 
        /// <returns>EntityGetResponse<BlogEngine> Object.</returns>
        public EntityGetResponse<BlogEngine> GetByFK_BlogEngine_BehaviourTypes(int BehaviourTypeId)
        {
            string storedProcedured = "EXEC gvdp.BlogEngine_GetByFK_BlogEngine_BehaviourTypes @BehaviourTypeId";
            DynamicParameters parameter = new DynamicParameters();
            parameter.Add("@BehaviourTypeId", BehaviourTypeId);
            objectGetResponse = this.GetListByParams(storedProcedured, parameter);
            return objectGetResponse;
        }
    }
}
