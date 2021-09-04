// ------------------------------------------------------------------
// <copyright file="EntityGetResponse.cs" company="Intergrupo S.A">
// Autor: Marbel Arrieta (marbel.arrieta@softwareone.com)
// Date: 08/11/2021 
// Source Code File C# - Intergrupo.Hermes
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
