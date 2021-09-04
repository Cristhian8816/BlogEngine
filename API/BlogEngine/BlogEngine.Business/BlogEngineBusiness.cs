// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Business
{
    using BlogEngine.Business.Interfaces;
    using BlogEngine.Entities.Model;
    using BlogEngine.Repository.Interfaces;
    using BlogEngine.Utils;
    using System;

    /// <summary>
    /// This class is responsible for executing the logic of the project.
    /// </summary>
    public class BlogEngineBusiness : IBlogEngineBusiness
    {
        /// <summary>
        /// BlogEngineRepository Interface object.
        /// </summary>
        private readonly IBlogEngineRepository _objectRepository;

        /// <summary>
        /// AuthorizationBusiness Declaration.
        /// </summary>
        

        /// <summary>
        /// Initializes a new instance of the <see cref="IBlogEngineRepository"/>
        /// </summary>
        /// <param name="objectRepository">This interface is required for inversion of control</param>
        public BlogEngineBusiness(IBlogEngineRepository objectRepository)
        {
            
            this._objectRepository = objectRepository;
        }

        /// <summary>
        /// Here goes the logic from the function GetList.
        /// </summary>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetList()
        {
            try
            {
                EntityResponse<BlogEngine> response = this._objectRepository.GetList();
                
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function GetById.
        /// </summary>
        /// <param name="objectGetById"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetById(EntityPrimaryKey objectGetById)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectGetById);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.GetById(objectGetById);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function delete.
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Delete(EntityPrimaryKey objectDelete)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectDelete);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.Delete(objectDelete);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function Insert.
        /// </summary>
        /// <param name="objectInsert">objectInsert value.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Insert(BlogEngineInsertRequest objectInsert, UsersAuthenticated userAuthenticated)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectInsert);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.Insert(objectInsert, userAuthenticated);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function Update.
        /// </summary>
        /// <param name="objectUpdate">objectUpdate value.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> Update(BlogEngine objectUpdate, UsersAuthenticated userAuthenticated)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectUpdate);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.Update(objectUpdate, userAuthenticated);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function GetListByParams.
        /// </summary>
        /// <param name="objectGetListByParams">objectGetListByParams value</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams, UsersAuthenticated userAuthenticated)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectGetListByParams);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.GetListByParams(objectGetListByParams, userAuthenticated);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function getListOrdered.
        /// </summary>
        /// <param name="objectGetListOrdered">objectGetListOrdered value.</param>
        /// <returns>BlogEngineResponse.</returns>
        public EntityResponse<BlogEngine> GetListOrdered(EntityGetListOrdered objectGetListOrdered)
        {
            try
            {
                EntityResponse<BlogEngine> response = ValidateObject(objectGetListOrdered);
                if (response.ResponseCode == 200)
                {
                    response = this._objectRepository.GetListOrdered(objectGetListOrdered);
                    
                }
                return response;
            }
            catch (BusinessException ex)
            {
                return ResponseError(ex.Message);
            }
            catch (Exception ex)
            {
                return ResponseError(ex.Message);
            }
        }

        /// <summary>
        /// Here goes the logic from the function delete.
        /// </summary>
        /// <param name="message">message error to print.</param>
        /// <returns>EntityResponse<BlogEngine>.</returns>
        private EntityResponse<BlogEngine> ResponseError(string message)
        {
            return new EntityResponse<BlogEngine>
            {
                ResponseCode = 400,
                IdTransactionCode = null,
                RowsAffected = 0,
                ResponseMessage = message,
                ResultData = null
            };
        }

        /// <summary>
        /// This function verify if the entity complies with the Data annotations.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityToValidate"></param>
        /// <returns></returns>
        private EntityResponse<BlogEngine> ValidateObject<T>(T entityToValidate) where T : class, new()
        {
            var isValidEntity = entityToValidate.Validate();
            return new EntityResponse<BlogEngine>()
            {
                ResponseCode = (isValidEntity.Count > 0) ? 400 : 200,
                ResponseMessage = (isValidEntity.Count > 0) ? String.Concat(isValidEntity) : null,
                IdTransactionCode = null,
                RowsAffected = 0,
                ResultData = null
            };
        }

    }
}
