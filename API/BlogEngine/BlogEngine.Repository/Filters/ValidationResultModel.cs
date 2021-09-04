// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Repository.Filters
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Collections.Generic;
    using System.Linq;

    public class ValidationResultModel
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

    public List<ValidationError> Errors { get; }

    public ValidationResultModel(ModelStateDictionary modelState)
    {

        ResponseCode = 400;
        ResponseMessage = "Bad Request";
        IdTransactionCode = "0";
        RowsAffected = 0;
        Errors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
    }
}

}
