// ------------------------------------------------------------------
// <copyright file="EntityGetResponse.cs" company="Zemoga">
// Autor: Inge Cristhian Gomez
// Date: 05/09/2021

// All rights reserved
// </copyright>
// ------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{
    public class  EntityGetResponse<T>
    {
        /// <summary>
        /// Gets or sets from ResultData.
        /// </summary>
        public Collection<T> ResultData;

        /// <summary>
        /// Gets or sets from TotalResults.
        /// </summary>
        public int TotalResults { get; set; }
    }
}
