// ------------------------------------------------------------------
// <copyright file="UserLogin.cs" company="Zemoga">
// Autor: Inge Cristhian Gomez
// Date: 08/09/2021 
// Source Code File C# 
// All rights reserved
// </copyright>
// ------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{
    /// <summary>
    /// Entity User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or Sets from User Name.
        /// </summary>
        [Required]
        public string userName { get; set; }

        /// <summary>
        /// Gets or Sets from User Password.
        /// </summary>
        [Required]
        public string userPassword { get; set; }
    }
}
