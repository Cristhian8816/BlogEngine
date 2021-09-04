// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Business.Interfaces
{
    using BlogEngine.Entities.Model;

    /// <summary>
    /// This is an interface for the type of TipoIdentificacionBusiness.
    /// </summary>
    public interface IBlogEngineBusiness
    {
        /// <summary>
        /// Get all the items from the entity.
        /// </summary>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> GetList();

        /// <summary>
        /// Get an item by its id from the entity.  
        /// </summary>
        /// <param name="objectGetById"></param>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> GetById(EntityPrimaryKey objectGetById);

        /// <summary>
        /// Delete an Item by its Id.
        /// </summary>
        /// <param name="objectDelete"></param>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> Delete(EntityPrimaryKey objectDelete);

        /// <summary>
        /// Insert an item into the entity.
        /// </summary>
        /// <param name="objectInsert"></param>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> Insert(BlogEngineInsertRequest objectInsert, UsersAuthenticated userAuthenticated);

        /// <summary>
        /// Update an item into the entity.
        /// </summary>
        /// <param name="objectUpdate"></param>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> Update(BlogEngine objectUpdate, UsersAuthenticated userAuthenticated);

        /// <summary>
        ///  Get the List depending on the paramaters sent.
        /// </summary>
        /// <param name="objectGetListByParams"></param>
        /// <returns>BlogEngineResponse</returns>
        EntityResponse<BlogEngine> GetListByParams(BlogEngineGetListByParams objectGetListByParams, UsersAuthenticated userAuthenticated);

        /// <summary>
        /// Get all the items from the entity with pagination.
        /// </summary>
        /// <param name="objectGetListOrdered"></param>
        /// <returns>This function returns a Response type</returns>
        EntityResponse<BlogEngine> GetListOrdered(EntityGetListOrdered objectGetListOrdered);
    }

}
