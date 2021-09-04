// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Utils
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Validate Entity
    /// </summary>
    public static class EntityValidator

    {
        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IList<string> Validate<T>(this T entity) where T : class, new()
        {
            var validatorContext = new ValidationContext(entity);
            var errors = new List<ValidationResult>();
            var responses = new List<string>();
            Validator.TryValidateObject(entity, validatorContext, errors, true);
            errors.ForEach(e => responses.Add(e.ErrorMessage));
            return responses;
        }
    }
}
