// ------------------------------------------------------------------
// <copyright file="EntityPrimaryKey.cs" company="Intergrupo S.A">
// Autor: Marbel Arrieta (marbel.arrieta@softwareone.com)
// Date: 08/11/2021 
// Source Code File C# - Intergrupo.Hermes
// All rights reserved
// </copyright>
// ------------------------------------------------------------------
using BlogEngine.Utils.Resources;
using System;
using System.ComponentModel.DataAnnotations;

// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{
    /// <summary>
    /// Entity EntityPrimaryKey.
    /// </summary>
    public class EntityPrimaryKey
    {

        /// <summary>
        /// Gets or Sets from Id.
        /// </summary>
        [Key]
        [Required]
        [Range(1, int.MaxValue, ErrorMessageResourceName = "modelLenghCharacterMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets from Date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
