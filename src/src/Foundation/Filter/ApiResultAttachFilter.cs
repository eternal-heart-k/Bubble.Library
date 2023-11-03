using Bubble.Library.Foundation.Dto.Common;
using Bubble.Library.src.Trace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using Bubble.Library.Foundation.Attribute;

namespace Bubble.Library.Foundation.Filter
{
    public class ApiResultAttachFilter : IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m is NotWarpApiResultAttribute))
            {
                return;
            }

            var operationId = TraceContext.OperationId;

            object value = context.Result switch
            {
                BadRequestObjectResult result => result,
                ObjectResult { Value: not ApiResult } result => ApiResult.Success(result.Value, operationId),
                EmptyResult => ApiResult.Success(operationId),
                _ => null
            };

            if (value is ApiResult)
            {
                context.Result = new OkObjectResult(value);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // nothing
        }
    }
}
