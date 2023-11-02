using Bubble.Library.Exception;
using Bubble.Library.Foundation.Dto.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Bubble.Library.src.Trace;
using Bubble.Library.src.Foundation.Constant;

namespace Bubble.Library.Foundation.Attribute
{
    /// <summary>
    /// API响应属性，为API调用接口包裹ApiResult
    /// </summary>
    public class ApiResponseAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 重写OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var operationId = TraceContext.OperationId;

            object value = context.Result switch
            {
                BadRequestObjectResult result => result,
                ObjectResult { Value: not ApiResult } result => ApiResult.Success(result.Value, operationId),
                EmptyResult => ApiResult.Success(operationId),
                _ => null
            };

            if (context.Exception is not null && context.Exception is StringResponseException strEx)
            {
                value = ApiResult.Error(strEx.ErrorCode, strEx.Message, operationId);
                context.ExceptionHandled = true;
                context.Result = new OkObjectResult(value) { StatusCode = StatusCodeConstants.BusinessException };
            }

            else if (value is ApiResult)
            {
                context.Result = new OkObjectResult(value);
            }
        }
    }
}
