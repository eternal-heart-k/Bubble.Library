using Bubble.Library.DependencyInjection;
using Bubble.Library.Foundation.Dto.Common;
using Bubble.Library.src.Trace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bubble.Library.src.Foundation.Filter
{
    public class ApiResultAttachFilter : IResultFilter, ITransientDependency
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
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

        }
    }
}
