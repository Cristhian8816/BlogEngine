using Dapper;
using Microsoft.Extensions.Configuration;
using BlogEngine.Entities.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BlogEngine.Repository
{
    public class DapperManager<T> : IDisposable
    {
        /// <summary>
        /// UserGetResponse object.
        /// </summary>
        private readonly EntityGetResponse<T> objectGetResponse;

        /// <summary>
        /// DbConnection interface.
        /// </summary>
        private readonly IDbConnection connection;

        /// <summary>
        /// In this constructor, the connection is initialized
        /// </summary>
        /// <param name="connectionString"></param>
        public DapperManager(IConfiguration config)
        {
            connection = new SqlConnection(config.GetConnectionString("DataMasters"));
            objectGetResponse = new EntityGetResponse<T>();
        }

        /// <summary>
        /// This method is responsible for getting all the items from the database.
        /// </summary>
        /// <returns></returns>
        public Collection<T> GetList(string storedProcedured)
        {
            connection.Open();
            var response = new ObservableCollection<T>(
                connection.Query<T>(storedProcedured).ToList()
                );
            Dispose();
            return response;
        }

        /// <summary>
        /// This method is responsible for getting an item from the database by its Id.
        /// </summary>
        /// <param name="storedProcedured">Query string that executes SP</param>
        /// <param name="parameters">Params from SP</param>
        /// <returns></returns>
        public T GetById(string storedProcedured, DynamicParameters parameters)
        {
            connection.Open();
            object QueryResponse = connection.Query<T>(storedProcedured,
                parameters).First();
            Dispose();
            return (T)Convert.ChangeType(QueryResponse, typeof(T));
        }

        /// <summary>
        /// This method is responsible for deleting an item from the database.
        /// </summary>
        /// <param name="storedProcedured">Query string that executes SP</param>
        /// <param name="parameters">Params from SP</param>
        /// <returns></returns>
        public int Delete(string storedProcedured, DynamicParameters parameters)
        {
            connection.Open();
            var RowsAffected = connection.Execute(storedProcedured, parameters);
            Dispose();
            return RowsAffected;
        }

        /// <summary>
        /// This method is responsible for making the insertion of an profile to the database.
        /// </summary>
        /// <param name="storedProcedured">Query string that executes SP</param>
        /// <param name="parameters">Params from SP</param>
        /// <returns></returns>
        public EntityInsertResponse Insert(string storedProcedured, DynamicParameters parameters)
        {
            connection.Open();
            EntityInsertResponse IdTransactionCode = connection.Query<EntityInsertResponse>(storedProcedured, parameters).First();
            Dispose();
            return IdTransactionCode;
        }

        /// <summary>
        /// This method is responsible for updating an profile from the database.
        /// </summary>
        /// <param name="storedProcedured">Query string that executes SP</param>
        /// <param name="parameters">Params from SP</param>
        /// <returns></returns>
        public int Update(string storedProcedured, DynamicParameters parameters)
        {
            connection.Open();
            int rowsAffected = connection.Execute(storedProcedured, parameters);
            Dispose();
            return rowsAffected;
        }

        /// <summary>
        /// This method is responsible for getting all the items from the entity depending on the parameters sent.
        /// </summary>
        /// <param name="storedProcedured">Query string that executes SP</param>
        /// <param name="parameters">Params from SP</param>
        /// <returns></returns>
        public EntityGetResponse<T> GetListByParams(string storedProcedured, DynamicParameters parameters)
        {
            connection.Open(); 
            using (var multipleResponse = connection.QueryMultiple(storedProcedured, parameters))
            {
                objectGetResponse.ResultData = new ObservableCollection<T>(multipleResponse.Read<T>().ToList());
                objectGetResponse.TotalResults = multipleResponse.Read<int>().First();
            }
            Dispose();
            return objectGetResponse;
        }       

        /// <summary>
        /// Close connection.
        /// </summary>
        public void Dispose()
        {
            connection.Close();
        }
    }
}
