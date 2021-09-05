// ------------------------------------------------------------------
// <copyright file="EntityResponse.cs" company="Zemoga">
// Autor: Inge Cristhian Gomez
// Date: 05/09/2021

// All rights reserved
// </copyright>
// ------------------------------------------------------------------
using System.Collections.ObjectModel;

// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Entities.Model
{

    /// <summary>
    /// Entity EntityResponse.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EntityResponse<T>
    {
        /// <summary>
        /// Gets or Sets from ResponseCode.
        /// </summary>
        public int ResponseCode { get; set; }

        /// <summary>
        /// Gets or Sets from ResponseMessage.
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Gets or Sets from IdTransactionCode.
        /// </summary>
        public string IdTransactionCode { get; set; }

        /// <summary>
        /// Gets or Sets from RowsAffected.
        /// </summary>
        public int RowsAffected { get; set; }

        /// <summary>
        /// Gets or Sets from ResultData.
        /// </summary>
        public Collection<T> ResultData { get; set; }

        /// <summary>
        /// Gets or Sets from Authorization.
        /// </summary>
        public string Authorization { get; set; }
    }
}
