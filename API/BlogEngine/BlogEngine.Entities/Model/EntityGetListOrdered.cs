// ------------------------------------------------------------------
// <copyright file="EntityGetListOrdered.cs" company="Intergrupo S.A">
// Autor: Marbel Arrieta (marbel.arrieta@softwareone.com)
// Date: 08/11/2021 
// Source Code File C# - Intergrupo.Hermes
// All rights reserved
// </copyright>
// ------------------------------------------------------------------
using BlogEngine.Utils.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{
    public class EntityGetListOrdered
    {
        /// <summary>
        /// Gets or sets from OrderBy.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        //[RegularExpression(@"^[a-zA-Z]{1,40}|[0-9]{1,40}$", ErrorMessageResourceName = "modelCharactersMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or set from Ascendent.
        /// </summary>
        [Required]
        public bool Ascendent { get; set; }

        /// <summary>
        /// Gets or set from PageNumber.
        /// </summary>
        [Range(1, long.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets from ResultsPerPage.
        /// </summary>
        [Range(1, long.MaxValue, ErrorMessageResourceName = "modelRequiredMessage", ErrorMessageResourceType = typeof(ResourceMessage))]
        public int ResultsPerPage { get; set; }
    }
}
