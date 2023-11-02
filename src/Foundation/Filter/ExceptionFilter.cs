using Bubble.Library.DependencyInjection;
using Bubble.Library.Exception;
using Bubble.Library.Foundation.Dto.Common;
using Bubble.Library.src.Foundation.Constant;
using Bubble.Library.src.Trace;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Bubble.Library.src.Foundation.Filter
{
    public class ExceptionFilter : IExceptionFilter, ITransientDependency
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is not null && context.Exception is StringResponseException strEx)
            {
                object value = ApiResult.Error(strEx.ErrorCode, strEx.Message, TraceContext.OperationId);
                context.ExceptionHandled = true;
                context.Result = new OkObjectResult(value) { StatusCode = StatusCodeConstants.BusinessException };
            }
        }
    }
}
