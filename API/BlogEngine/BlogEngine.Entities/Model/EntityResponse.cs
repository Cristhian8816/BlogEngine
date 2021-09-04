// ------------------------------------------------------------------
// <copyright file="EntityResponse.cs" company="Intergrupo S.A">
// Autor: Marbel Arrieta (marbel.arrieta@softwareone.com)
// Date: 08/11/2021 
// Source Code File C# - Intergrupo.Hermes
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
