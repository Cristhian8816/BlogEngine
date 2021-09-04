// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Repository.Filters
{
    using Microsoft.AspNetCore.Mvc.Filters;

    public class ValidateModelAttribute : ActionFilterAttribute
  {
      public override void OnActionExecuting(ActionExecutingContext context)
      {
          if (!context.ModelState.IsValid)
          {
              context.Result = new ValidationFailedResult(context.ModelState);
          }
      }
  }

}
