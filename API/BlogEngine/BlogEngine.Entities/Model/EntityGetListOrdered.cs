// ------------------------------------------------------------------
// <copyright file="EntityGetListOrdered.cs" company="Zemoga">
// Autor: Inge Cristhian Gomez
// Date: 05/09/2021

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
