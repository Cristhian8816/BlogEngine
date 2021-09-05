// ------------------------------------------------------------------
// <copyright file="UsersAuthenticated.cs" company="Zemoga">
// Author: Cristhian Julian Gomez (cristhian.gomez@softwareone.com)
// Date: 08/30/2021 

// All rights reserved
// </copyright>
// ------------------------------------------------------------------

namespace BlogEngine.Entities.Model
{
    using global::BlogEngine.Utils.Resources;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Entity UsersAuthenticated.
    /// </summary>   
    public class UsersAuthenticated
    {

        /// <summary>
        /// Gets or Sets from Name.
        /// </summary>
        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets from User Email.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string email { get; set; }
    }
}
