using Car.Shared.Result.Concrete;
using Car.Shared.Result.Type;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Api.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        //hata geldiğinde çalıştır
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");

                Dictionary<string, string> validationErrors = new Dictionary<string, string>();

                validationErrors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).First()
                );
                result.validationErrors = validationErrors;
                context.Result = new OkObjectResult(result);
            }
        }
    }
}
