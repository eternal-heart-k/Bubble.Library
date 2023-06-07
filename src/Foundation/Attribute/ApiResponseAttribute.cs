using Bubble.Library.Exception;
using Bubble.Library.Extension;
using Bubble.Library.Foundation.Dto.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bubble.Library.Foundation.Attribute
{
    public class ApiResponseAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var exception = context.Exception;
            if (exception is not null)
            {
                var apiResult = new ApiResult
                {
                    Message = exception.Message,
                    IsSuccess = false,
                    OperationId = StringHelper.GetNewGuid("N"),
                };
                if (exception is StringResponseException)
                {
                    context.ExceptionHandled = true;
                    context.Result = new ObjectResult(apiResult)
                    {
                        StatusCode = 288
                    };
                }
                else
                {
                    context.Result = new ObjectResult(apiResult);
                }
            }
            else if (context.Result is ObjectResult objectResult)
            {
                var result = objectResult.Value;
                context.Result = new ObjectResult(new ApiResult<object>
                {
                    Result = result,
                    IsSuccess = true,
                    OperationId = StringHelper.GetNewGuid("N"),
                });
            }
        }
    }
}
